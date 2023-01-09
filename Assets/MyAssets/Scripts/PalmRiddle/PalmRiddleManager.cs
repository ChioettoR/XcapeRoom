using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class PalmRiddleManager : MonoBehaviour
{
    public List<Interactable> collectableObjects;
    public GobletFiller gobletFiller;
    public GameObject gobletDockZone;
    public List<ParticleSystem> waterDripParticles;

    private int correctObjectsPlaced;
    private bool gobletPlaced = false;
    private bool gobletFilled = false;

    public void CorrectObjectPlaced()
    {
        correctObjectsPlaced++;

        if (correctObjectsPlaced == 2)
        {
            foreach (Interactable interactable in collectableObjects) interactable.enabled = false;
            ActiveFountain();
        }
    }

    public void CorrectObjectRemoved()
    {
        correctObjectsPlaced--;
    }

    public void GobletPlaced()
    {
        gobletPlaced = true;
        if (correctObjectsPlaced == 2)
        {
            gobletFiller.Fill();
            gobletFilled = true;
        }
    }

    public void GobletRemoved()
    {
        gobletPlaced = false;

        if(gobletFilled) gobletDockZone.SetActive(false);
    }

    private void ActiveFountain()
    {
        foreach (ParticleSystem particleSystem in waterDripParticles) particleSystem.Play();
        if (gobletPlaced) 
        {
            gobletFiller.Fill();
            gobletFilled = true;
        }
    }
}
