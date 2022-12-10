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

    public void AddItem(CollectableObject collectableObject)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].CheckAvailable())
            {
                AddObjectToInventory(collectableObject, slots[i]);
                break;
            }
        }
    }

    private void AddObjectToInventory(CollectableObject collectableObject, InventorySlot inventorySlot)
    {
        inventorySlot.SetInventoryObject(collectableObject);
    }
}
