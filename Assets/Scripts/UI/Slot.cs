using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image image;
    private Item item;

    private Transform myParent;
    private Transform targetParent;
    private Transform canvas;

    private Vector3 myPos;
    public void Awake()
    {
        image = GetComponent<Image>();
        myParent = transform.parent.GetComponent<Transform>();
        canvas = transform.root;
        myPos = transform.localPosition;
    }
    public void Update()
    {
        SyncItemVisual();
    }
    public void AssginItem(Item _item)
    {
        item = _item;
    }
    public void ClearItem()
    {
        item = null;
    }
    public void SyncItemVisual()
    {
        if (item != null)
        {
            image.sprite = item.itemSprite;
            image.raycastTarget = true;
        }
        else
        {
            image.sprite = null;
            image.raycastTarget = false;
        }
    }
    public Item GetItem()
    {
        return item;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(canvas);
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //모바일 대응시 mousePosition이 아닌 Input.touches를 사용하거나 fingerId 사용
        Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray2D ray = new Ray2D(wp, Vector2.zero);
        RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
        Debug.Log(hits.Length);
        foreach (RaycastHit2D hit in hits)
        {
            if(hit.collider.TryGetComponent(out Miner _miner))
            {
                _miner.health.EditHealthData(item.healthType, item.healthValue);
                image.sprite = null;
                ClearItem();
            }
        }
        transform.SetParent(myParent);
        transform.localPosition = myPos;
        image.raycastTarget = true;
    }
}
