using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<Slot> slotList = new List<Slot>();
    public const string SLOT_PATH = "InventoryCanvas/InventoryPanel/Inventory";
    public GameObject dropItemPrefab;


    public void Start()
    {
        Slot[] slots = GameObject.Find(SLOT_PATH).GetComponentsInChildren<Slot>();
        foreach (Slot slot in slots)
        {
            slotList.Add(slot);
        }
    }
    public void AddItem(Item _item)
    {
        for (int i = 0; i < slotList.Count; i++)
        {
            if(slotList[i].GetItem() == null)
            {
                slotList[i].AssginItem(_item);
                return;
            }
        }
        // 여기로 넘어왔다는 것 자체가 인벤토리가 가득 찬 것
        Debug.Log("Inven Is Full");
        DropItem(_item);
    }
    public void DropItem(Item _item)
    {
        DropedItem dropedItem = Instantiate(dropItemPrefab).GetComponent<DropedItem>();
        float randomX = Random.Range(-2f, 2f);
        float randomY = Random.Range(-2f, 2f);
        dropedItem.transform.position += new Vector3(randomX, randomY, 0);
        dropedItem.item = _item;
        dropedItem.GetComponent<SpriteRenderer>().sprite = _item.itemSprite;
    }
}
