using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> slots;

    public void HideInventoryObject()
    {
        foreach (InventorySlot inventorySlot in slots) inventorySlot.HideObject();
    }

    public void AddItem(InventoryObject inventoryObject)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].CheckAvailable())
            {
                AddObjectToInventory(inventoryObject, slots[i]);
                break;
            }
        }
    }

    private void AddObjectToInventory(InventoryObject inventoryObject, InventorySlot inventorySlot)
    {
        inventorySlot.SetInventoryObject(inventoryObject);
    }
}
