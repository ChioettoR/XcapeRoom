using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using UnityEngine;

public class MenuPinManager : MonoBehaviour
{
    public List<BoundsControl> boundsControls;
    public FollowMeToggle followMeToggle;

    public void PinActive()
    {
        ShowBoundsControls(true);
        followMeToggle.ToggleFollowMeBehavior();
    }

    public void ShowBoundsControls(bool show)
    {
        foreach (BoundsControl boundsControl in boundsControls) boundsControl.Active = show;
    }

    public void PinDeactive()
    {
        ShowBoundsControls(false); 
        followMeToggle.ToggleFollowMeBehavior();
    }
}
