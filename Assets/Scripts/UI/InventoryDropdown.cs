using UnityEngine;
using UnityEngine.UI;

public class InventoryDropdown : MonoBehaviour
{
    public RectTransform panelRect;
    public bool flag;

    private Vector2 panelPos;
    private Vector2 canvasScale;
    public void Awake()
    {
        panelPos = panelRect.anchoredPosition;
        canvasScale = panelRect.GetComponentInParent<CanvasScaler>().referenceResolution;
        panelRect.anchoredPosition = new Vector2(panelRect.anchoredPosition.x - (canvasScale.x + panelRect.sizeDelta.x), panelRect.anchoredPosition.y);
        flag = false;
    }
    public void DropdownBt()
    {
        if(flag == true)
        {
            panelRect.anchoredPosition = new Vector2(panelRect.anchoredPosition.x - (canvasScale.x + panelRect.sizeDelta.x), panelRect.anchoredPosition.y);
            flag = false;
        }
        else
        {
            panelRect.anchoredPosition = panelPos;
            flag = true;
        }
    }
}
