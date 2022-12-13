using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class InventoryMovableObject : MonoBehaviour
{
    public string objectTag;
    public bool canBeRemoved;
    public Vector3 parentRotation;
    public AgnusCombination agnusCombination;

    private bool correctPosition = false;
    private Transform parentPosition;
    private ObjectManipulator objectManipolator;
    private InventorySlot inventorySlot;
    private CollectableObject collectableObject;
    private MultipleDockZone enteredZone;

    private void Awake()
    {
        objectManipolator = GetComponent<ObjectManipulator>();
        collectableObject = GetComponent<CollectableObject>();

        objectManipolator.enabled = false;
    }

    public void ActiveManipulator(bool active)
    {
        objectManipolator.enabled = active;
    }

    public void SetSlot(InventorySlot inventorySlot)
    {
        this.inventorySlot = inventorySlot;
    }

    public void EnteredCorrectPosition(Transform parentPosition, MultipleDockZone multipleDockZone)
    {
        enteredZone = multipleDockZone;
        this.parentPosition = parentPosition;
        correctPosition = true;
    }

    public void LeftCorrectPosition()
    {
        this.parentPosition = null;
        correctPosition = false;
    }

    public void CheckPosition()
    {
        if (!correctPosition) ResetPosition();
        else
        {
            SetParent();
            inventorySlot.RemoveInventoryObject();

            enteredZone.Taken(true);

            if (enteredZone.correctObjectTag.Equals(objectTag)) agnusCombination.Correct();
        }
    }

    public void CollectedAgain()
    {
        if (enteredZone)
        {
            enteredZone.Taken(false);
            if (enteredZone.correctObjectTag.Equals(objectTag)) agnusCombination.CorrectRemoved();
        }
    }

    public void ResetPosition()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(parentRotation);
    }

    private void SetParent()
    {
        objectManipolator.enabled = false;

        transform.parent = null;
        transform.position = parentPosition.position;
        transform.rotation = parentPosition.rotation;

        if (canBeRemoved) collectableObject.ActiveCollect(true);
    }
}
