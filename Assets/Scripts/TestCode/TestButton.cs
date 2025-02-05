using UnityEngine;

public class TestButton : MonoBehaviour
{
    public Item item;
    public void AddItemButton()
    {
        InventoryManager.Instance.AddItem(item);
    }
}
