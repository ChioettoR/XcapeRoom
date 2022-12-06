using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class InventoryMovableObject : MonoBehaviour
{
    public string objectTag;

    private Vector3 initialTransformPosition;
    private Quaternion initialTransformRotation;

    private bool correctPosition = false;
    private Transform parentPosition;
    private ObjectManipulator objectManipolator;
    private InventorySlot inventorySlot;

    private void Awake()
    {
        objectManipolator = GetComponent<ObjectManipulator>();
    }

    private void OnEnable()
    {
        initialTransformPosition = transform.position;
        initialTransformRotation = transform.rotation;
    }

    public void SetSlot(InventorySlot inventorySlot)
    {
        this.inventorySlot = inventorySlot;
    }

    public void EnteredCorrectPosition(Transform parentPosition)
    {
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
        }
    }

    private void ResetPosition()
    {
        transform.SetPositionAndRotation(initialTransformPosition, initialTransformRotation);
    }

    private void SetParent()
    {
        objectManipolator.enabled = false;

        transform.parent = parentPosition;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
