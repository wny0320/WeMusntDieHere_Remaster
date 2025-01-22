using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Maps : MonoBehaviour
{
    private bool isMap;
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
        this.isMap = isMap;
        this.pos = pos;

        if (!isMap)
        {
            gameObject.SetActive(false);
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

    private IEnumerator MoveMapCoroutine()
    {
        yield return StartCoroutine(MapManager.Instance.Fade(true));
        ChangeMap();
        yield return StartCoroutine(MapManager.Instance.Fade(false));
    }

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
