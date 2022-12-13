using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class NewInventoryManager : MonoBehaviour
{
    public List<Interactable> slotInteractables;
    public List<NewInventorySlot> slots;

    private PressableDockZone selectedDockZone;

    public void SetSelectedDockZone(PressableDockZone pressableDockZone)
    {
        selectedDockZone = pressableDockZone;
    }

    public PressableDockZone GetSelectedDockZone()
    {
        return selectedDockZone;
    }

    public void AddItem(NewCollectableObject newCollectableObject)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].CheckAvailable())
            {
                AddObjectToInventory(newCollectableObject, slots[i]);
                break;
            }
        }
    }

    private void AddObjectToInventory(NewCollectableObject newCollectableObject, NewInventorySlot inventorySlot)
    {
        inventorySlot.SetInventoryObject(newCollectableObject);
    }

    private void Awake()
    {
        ActiveInteractables(false);
    }

    public void ActiveInteractables(bool active)
    {
        foreach (Interactable slotInteractable in slotInteractables) slotInteractable.enabled = active;
    }
}
