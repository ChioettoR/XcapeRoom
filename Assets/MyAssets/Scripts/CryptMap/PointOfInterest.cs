using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class PointOfInterest : MonoBehaviour
{
    public POIManager POIManager;
    public GameObject associatedObject;
    public CompassDirection compassDirection;

    private Interactable interactable;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
    }

    public void Select()
    {
        POIManager.Click(interactable);
        compassDirection.SetTarget(associatedObject.transform);
    }

    public void Deselect()
    {
        compassDirection.RemoveTarget();
    }
}
