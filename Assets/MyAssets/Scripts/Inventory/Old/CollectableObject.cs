using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public Sprite sprite;
    public InventoryManager inventoryManager;

    private Interactable interactable;
    private InventoryMovableObject inventoryMovableObject;

    private void Awake()
    {
        inventoryMovableObject = GetComponent<InventoryMovableObject>();
        interactable = GetComponent<Interactable>();
    }

    public void Collect()
    {
        inventoryManager.AddItem(this);
        gameObject.SetActive(false);
        inventoryMovableObject.CollectedAgain();
    }

    public void ActiveCollect(bool active)
    {
        interactable.enabled = active;
    }
}
