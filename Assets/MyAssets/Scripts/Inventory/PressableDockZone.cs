using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class PressableDockZone : MonoBehaviour
{
    public NewMenuManager newMenuManager;
    public AgnusCombination agnusCombination;
    public List<string> acceptedObjectsTag;
    public string correctObjectTag;
    public GameObject objectParent;

    private Interactable interactable;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
    }

    public Interactable GetInteractable()
    {
        return interactable;
    }

    public void Select()
    {
        PressableDockZone selectedPressableDockZone = newMenuManager.newInventoryManager.GetSelectedDockZone();
        if(selectedPressableDockZone!=null && selectedPressableDockZone!= this) selectedPressableDockZone.GetInteractable().IsToggled = false;

        newMenuManager.OpenInventoryAndActiveSlots(this);
    }

    public void Deselect()
    {
        newMenuManager.ActiveMenu();
    }

    public void InsertObject(NewCollectableObject collectableObject)
    {
        collectableObject.gameObject.transform.SetPositionAndRotation(objectParent.transform.position, objectParent.transform.rotation);
        collectableObject.gameObject.SetActive(true);

        ActiveZone(false);

        collectableObject.SetPressableDockZone(this);

        if(collectableObject.objectTag.Equals(correctObjectTag)) agnusCombination.Correct();
    }

    public void RemoveObject(NewCollectableObject collectableObject)
    {
        ActiveZone(true);
        if (collectableObject.objectTag.Equals(correctObjectTag)) agnusCombination.CorrectRemoved();
    }

    public void ActiveZone(bool active)
    {
        interactable.IsToggled = false;
        gameObject.SetActive(active);
    }
}
