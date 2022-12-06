using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockZone : MonoBehaviour
{
    public string objectTag;
    public Transform objectPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("MovableObject"))
        {
            InventoryMovableObject inventoryMovableObject = other.GetComponent<InventoryMovableObject>();
            if(inventoryMovableObject.objectTag.Equals(objectTag)) inventoryMovableObject.EnteredCorrectPosition(objectPosition);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("MovableObject"))
        {
            InventoryMovableObject inventoryMovableObject = other.GetComponent<InventoryMovableObject>();
            if (inventoryMovableObject.objectTag.Equals(objectTag)) inventoryMovableObject.LeftCorrectPosition();
        }
    }
}
