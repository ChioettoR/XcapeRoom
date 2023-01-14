using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using UnityEngine;

public class MoveObjectsManager : MonoBehaviour
{
    public List<BoundsControl> boundsControls;
    public List<Collider> colliders;

    public void MoveObjects()
    {
        foreach (BoundsControl boundsControl in boundsControls) boundsControl.Active = !boundsControl.Active;
        foreach (Collider collider in colliders) collider.enabled = !collider.enabled;
    }
}
