using UnityEngine;
using System;
using UnityEngine.UI;

public class Maps : MonoBehaviour
{
    private bool isMap;
    private Vector2Int pos;
    private Sprite MapSprite;
    private MapType mapType;

    public bool isVisited = false;

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
        int rand = UnityEngine.Random.Range(0, Enum.GetValues(typeof(MapType)).Length);
        mapType = (MapType)rand;

        //юс╫ц
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
            Debug.Log(pos);
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

}
