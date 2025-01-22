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
}
