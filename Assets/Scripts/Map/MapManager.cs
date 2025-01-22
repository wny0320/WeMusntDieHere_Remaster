using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MapManager : Singleton<MapManager>
{
    Vector2Int[] dirs = { Vector2Int.down, Vector2Int.up, Vector2Int.left, Vector2Int.right };

    //홀수 여야됨
    [SerializeField] int height = 10;
    [SerializeField] int width = 10;
    [SerializeField] GameObject MapHolder;

    private bool[,] map;
    private Maps[] mapInfo;
    List<Vector2Int> EscapeCandidate = new List<Vector2Int>();

    public Vector2Int playerPos = Vector2Int.one;
    public SpriteRenderer mapSprite;

    [SerializeField] Image FadeUI;


    void Start()
    {
        GetMaps();
        GenerateMap();
        RenderMaps();
        SetEscapeMap();
    }

    private void GetMaps()
    {
        mapInfo = MapHolder.GetComponentsInChildren<Maps>();
    }

    public void GenerateMap()
    {
        height = height + 2; width = width + 2; //맞춰주기 위해
        map = new bool[height, width];
        Vector2Int current = playerPos; //시작
        map[current.x, current.y] = true;

        Stack<Vector2Int> stack = new Stack<Vector2Int>();
        stack.Push(current);

        while (stack.Count > 0)
        {
            current = stack.Pop();
            List<Vector2Int> neighbors = GetUnvisitedNeighbors(current);

            if (neighbors.Count > 0)
            {
                stack.Push(current);

                // 무작위로 이웃 선택
                Vector2Int chosen = neighbors[Random.Range(0, neighbors.Count)];

                // 현재 위치와 선택된 위치 사이의 벽을 부수기
                Vector2Int between = (current + chosen) / 2;
                map[between.x, between.y] = true;

                map[chosen.x, chosen.y] = true;
                stack.Push(chosen);
            }
        }
    }

    private List<Vector2Int> GetUnvisitedNeighbors(Vector2Int cell)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();

        foreach (Vector2Int dir in dirs)
        {
            Vector2Int neighbor = cell + dir * 2;

            if (IsInBound(neighbor.x, neighbor.y) && map[neighbor.x, neighbor.y] == false)
                neighbors.Add(neighbor);
        }

        if (neighbors.Count < 1) EscapeCandidate.Add(cell);

        return neighbors;
    }

    private bool IsInBound(int x, int y)
    {
        return x > 0 && x < height - 1 && y > 0 && y < width - 1;
    }

    void RenderMaps()
    {
        int pos = 0;
        for (int i = 1; i < height - 1; i++)
        {
            for (int j = 1; j < width - 1; j++)
            {
                mapInfo[pos].Init(map[i, j], new Vector2Int(i, j));
                pos++;
            }
        }
    }

    void SetEscapeMap()
    {
        EscapeCandidate = EscapeCandidate.Where(x => CheckEscapeBound(x)).ToList();
        EscapeCandidate.Remove(new Vector2Int(1, 1));

        //Vector2Int t = EscapeCandidate[Random.Range(0, temp.Count)];
        foreach (var t in EscapeCandidate)
        {
            mapInfo[(t.x - 1) * (width - 2) + t.y - 1].SetEscape();
        }
    }

    bool CheckEscapeBound(Vector2Int v)
    {
        int nearCount = 0;

        if (IsInBound(v.x, v.y))
        {
            foreach (Vector2Int dir in dirs)
            {
                if (map[(v.x + dir.x), (v.y + dir.y)])
                    nearCount++;
            }
        }

        if (nearCount > 1) return false;
        return true;
    }


    public IEnumerator Fade(bool isFade)
    {
        FadeUI.gameObject.SetActive(true);
        float timer = 0f;
        while (timer <= 2f)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;
            FadeUI.color = Color.Lerp(isFade ? new Color(0, 0, 0, 0) : new Color(0, 0, 0, 1), isFade ? new Color(0, 0, 0, 1) : new Color(0, 0, 0, 0), timer);
        }

        FadeUI.gameObject.SetActive(false);
    }
}