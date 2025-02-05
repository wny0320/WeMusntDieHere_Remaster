using UnityEngine;

public class DropedItem : MonoBehaviour
{
    public Item item;

    public void Update()
    {
        DropItemClicked();
    }
    public void DropItemClicked()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(wp, Vector2.zero);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction);
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.TryGetComponent(out DropedItem dropedItem))
                {
                    // �� ���� ������Ʈ�� �ƴϾ dropedItem�� ������ ������ �۵��� �ع���
                    if(dropedItem.gameObject == gameObject)
                    {
                        InventoryManager.Instance.AddItem(item);
                        Destroy(gameObject);
                        return;
                    }
                }
            }
        }
    }
}
