using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public InventoryObject inventoryObject;

    public void Collect()
    {
        inventoryManager.AddItem(inventoryObject);
        Destroy(gameObject);
    }
}
