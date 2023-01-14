using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.Events;

public class PressableDockZone : MonoBehaviour
{
    public NewMenuManager newMenuManager;
    public UnityEvent placedCorrectEvent;
    public UnityEvent removedCorrectEvent;
    public List<string> acceptedObjectsTag;
    public string correctObjectTag;
    public GameObject objectParent;
    public bool canRemoveObject = true;
    public bool setParent = false;
    public bool resetScale = false;

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

        if (setParent) collectableObject.transform.parent = objectParent.transform;
        if (resetScale) collectableObject.transform.localScale = Vector3.one;

        ActiveZone(false);

        collectableObject.SetPressableDockZone(this);

        if (collectableObject.objectTag.Equals(correctObjectTag)) placedCorrectEvent.Invoke();

        if (!canRemoveObject)
        {
            interactable.enabled = false;
            collectableObject.GetComponent<Interactable>().enabled = false;
        }
    }

    public void RemoveObject(NewCollectableObject collectableObject)
    {
        ActiveZone(true);
        if (collectableObject.objectTag.Equals(correctObjectTag)) removedCorrectEvent.Invoke();
    }

    public void ActiveZone(bool active)
    {
        interactable.IsToggled = false;
        gameObject.SetActive(active);
    }
}
