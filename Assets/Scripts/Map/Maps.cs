using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class Maps : MonoBehaviour
{
    private Vector2Int pos;
    private Sprite MapSprite;
    private MapType mapType;

    public void Init(bool isMap, Vector2Int pos, MapType mapType)
    {
        this.pos = pos;
        this.mapType = mapType;

        if (!isMap)
        {
            GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
            Destroy(GetComponent<Button>());
            return;
        }

        SetMap(mapType);
        GetComponent<Button>().onClick.AddListener(OnClickMap);
    }

    private void SetMap(MapType mapType)
    {
        //임시
        Image img = GetComponent<Image>();
        switch(mapType)
        {
            case MapType.Trap:
                img.color = Color.red;
                break;
            case MapType.Water:
                img.color = Color.blue;
                break;
            case MapType.BaseCamp:
                img.color = Color.yellow;
                break;
            case MapType.Escape:
                img.color = Color.black;
                break;
        }
    }

    public void OnClickMap()
    {
        if (CheckNear())
        {
            MapManager.Instance.SetPlayerPos(pos);
            //MapManager.Instance.SaveMap();
            StartCoroutine(MoveMapCoroutine());
        }
        else
        {
            Debug.Log("You Cant Move There");
        }
    }

    private bool CheckNear()
    {
        if ((MapManager.Instance.GetPlayerPos() - pos).magnitude == 1f)
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
