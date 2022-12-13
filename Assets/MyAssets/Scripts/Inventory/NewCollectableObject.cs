using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class NewCollectableObject : MonoBehaviour
{
    public string objectTag;
    public Sprite sprite;
    public NewInventoryManager newInventoryManager;

    private Interactable interactable;
    private PressableDockZone pressableDockZoneWhereInserted;

    private void Awake()
    {
        interactable = GetComponent<Interactable>();
    }

    public void SetPressableDockZone(PressableDockZone pressableDockZoneWhereInserted)
    {
        this.pressableDockZoneWhereInserted = pressableDockZoneWhereInserted;
    }

    public void Collect()
    {
        if (pressableDockZoneWhereInserted) pressableDockZoneWhereInserted.RemoveObject(this);

        newInventoryManager.AddItem(this);
        gameObject.SetActive(false);
    }

    public void ActiveCollect(bool active)
    {
        interactable.enabled = active;
    }
}
