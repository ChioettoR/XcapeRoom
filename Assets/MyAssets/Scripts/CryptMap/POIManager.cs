using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class POIManager : MonoBehaviour
{
    public List<Interactable> pointOfInterests;

    public void Click(Interactable clickedInteractable)
    {
        foreach (Interactable interactable in pointOfInterests)
        {
           if(clickedInteractable != interactable) interactable.IsToggled = false;
        }
    }
}
