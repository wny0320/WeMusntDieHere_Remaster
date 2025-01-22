using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public Item item;

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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            Debug.Log(hit.collider.gameObject.name);
            if(hit.rigidbody.TryGetComponent(out Miner _miner))
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
