using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class GobletHolderFinal : MonoBehaviour
{
    public Animator drawerAC;
    public GobletFiller gobletFiller;
    public Interactable gobletInteractable;
    public Interactable gobletStandInteractable;

    public void GobletInserted()
    {
        gobletInteractable.enabled = false;

        if (gobletFiller.CheckFilled()) drawerAC.SetTrigger("OpenDrawer");
        else drawerAC.SetTrigger("GobletStandDown");
    }

    public void GobletRemoved()
    {
        gobletStandInteractable.enabled = false;
        drawerAC.SetTrigger("GobletStandUp");
    }

    public void GobletDownAnimationFinished()
    {
        gobletInteractable.enabled = true;
    }

    public void GobletUpAnimationFinished()
    {
        gobletStandInteractable.enabled = true;
    }
}
