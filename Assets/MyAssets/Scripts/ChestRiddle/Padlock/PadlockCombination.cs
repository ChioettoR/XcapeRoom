using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using UnityEngine;

public class PadlockCombination : MonoBehaviour
{
    public List<char> charsOrder;
    public float charsAngleOffset;
    public PadlockManager padlockManager;

    private Vector3 initialPosition;
    private char charSelected;
    private BoundsControl boundsControl;

    private void Awake()
    {
        boundsControl = GetComponent<BoundsControl>();
        charSelected = charsOrder[0];
        initialPosition = transform.forward;
    }

    public char GetCharSelected()
    {
        return charSelected;
    }

    public void StopManipulation()
    {
        boundsControl.enabled = false;
    }

    public void CalculateChar()
    {
        int charSelectedInt = (int) Mathf.Repeat(Mathf.RoundToInt((Vector3.SignedAngle(transform.forward, initialPosition, Vector3.up) / charsAngleOffset)), charsOrder.Count);
        charSelected = charsOrder[charSelectedInt];
        padlockManager.UpdateCombination();
    }
}
