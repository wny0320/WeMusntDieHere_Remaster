using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEditor.SceneManagement;

public class Maps : MonoBehaviour
{
    private Vector2Int pos;
    private Sprite MapSprite;
    private MapType mapType;

    public bool isVisited = false;

    public void SetEscape()
    {
        mapType = MapType.Escape;

        //임시
        Image img = GetComponent<Image>();
        img.color = Color.black;
    }

    public void Init(bool isMap, Vector2Int pos)
    {
        this.pos = pos;

        if (!isMap)
        {
            GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
            Destroy(GetComponent<Button>());
            return;
        }

        SetRandMap();
        GetComponent<Button>().onClick.AddListener(OnClickMap);
    }

    private void SetRandMap()
    {
        int rand = UnityEngine.Random.Range(0, Enum.GetValues(typeof(MapType)).Length -1);
        mapType = (MapType)rand;

        //임시
        Image img = GetComponent<Image>();
        switch(rand)
        {
            case 1:
                img.color = Color.red;
                break;
            case 2:
                img.color = Color.blue;
                break;
            case 3:
                img.color = Color.yellow;
                break;
        }
    }

    public void OnClickMap()
    {
        if (CheckNear())
        {
            MapManager.Instance.playerPos = pos;
            StartCoroutine(MoveMapCoroutine());
        }
        else
        {
            Debug.Log("You Cant Move There");
        }
    }

    private bool CheckNear()
    {
        if ((MapManager.Instance.playerPos - pos).magnitude == 1f)
            return true;
        return false;
    }

    //mapmanager에 옮기던가 해야됨
    private IEnumerator MoveMapCoroutine()
    {
        yield return StartCoroutine(MapManager.Instance.Fade(true));
        ChangeMap();
        yield return StartCoroutine(MapManager.Instance.Fade(false));
    }

    //맵 이동시 호출됨 - 임시 코드
    private void ChangeMap()
    {
        switch (mapType)
        {
            case MapType.Ground:
                MapManager.Instance.mapSprite.color = Color.gray;
                break;
            case MapType.Trap:
                MapManager.Instance.mapSprite.color = Color.red;
                break;
            case MapType.Water:
                MapManager.Instance.mapSprite.color = Color.cyan;
                break;
            case MapType.BaseCamp:
                MapManager.Instance.mapSprite.color = Color.yellow;
                break;
        }
    }
}
