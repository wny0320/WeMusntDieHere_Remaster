using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<Slot> SlotList = new List<Slot>();
    public const string SLOT_PATH = "InventoryCanvas/InventoryPanel/Inventory";

    public void Start()
    {
        Slot[] slots = FindObjectsByType<Slot>(FindObjectsSortMode.None);
        foreach (Slot slot in slots)
        {
            SlotList.Add(slot);
            Debug.Log(slot.gameObject.name);
        }
    }
}
