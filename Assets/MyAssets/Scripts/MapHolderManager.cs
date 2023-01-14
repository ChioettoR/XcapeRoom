using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class MapHolderManager : MonoBehaviour
{
    public List<Interactable> dockZones;
    public Animator animator;
    private int insertedPieces = 0;

    private void Awake()
    {
        foreach (Interactable interactable in dockZones)
        {
            interactable.enabled = false;
            interactable.gameObject.SetActive(false);
        }
        ShowDockZone();
    }

    public void MapInserted()
    {
        insertedPieces++;
        if (insertedPieces == 3) MapCompleted();
        else ShowDockZone();
    }

    private void ShowDockZone()
    {
        Interactable dockZoneToEnable = dockZones[insertedPieces];
        dockZoneToEnable.enabled = true;
        dockZoneToEnable.gameObject.SetActive(true);
    }

    private void MapCompleted()
    {
        animator.SetTrigger("Play");
    }
}
