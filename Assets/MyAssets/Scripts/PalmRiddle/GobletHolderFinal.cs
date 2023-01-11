using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class GobletHolderFinal : MonoBehaviour
{
    public Animator drawerAC;
    public GobletFiller gobletFiller;
    public Interactable gobletInteractable;

    public void GobletInserted()
    {
        if(gobletFiller.CheckFilled())
        {
            gobletInteractable.enabled = false;
            drawerAC.SetTrigger("OpenDrawer");
        }
    }
}
