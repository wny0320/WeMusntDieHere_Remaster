using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<Slot> slotList = new List<Slot>();
    public const string SLOT_PATH = "InventoryCanvas/InventoryPanel/Inventory";


    public void Start()
    {
        Slot[] slots = FindObjectsByType<Slot>(FindObjectsSortMode.None);
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
    }
}
