using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class MultipleDockZone : MonoBehaviour
{
    public string correctObjectTag;
    public Transform objectPosition;
    public LayerMask objectsLayerMask;

    private bool taken = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!taken && ((1 << other.gameObject.layer) & objectsLayerMask) != 0)
        {
            InventoryMovableObject inventoryMovableObject = other.GetComponent<InventoryMovableObject>();
            inventoryMovableObject.EnteredCorrectPosition(objectPosition, this);
        }
    }

    public void Taken(bool taken)
    {
        this.taken = taken;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!taken && ((1 << other.gameObject.layer) & objectsLayerMask) != 0)
        {
            InventoryMovableObject inventoryMovableObject = other.GetComponent<InventoryMovableObject>();
            inventoryMovableObject.LeftCorrectPosition();
        }
    }
}
