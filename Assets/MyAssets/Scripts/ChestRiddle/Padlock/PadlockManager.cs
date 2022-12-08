using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;

public class PadlockManager : MonoBehaviour
{
    public string combination;
    public List<PadlockCombination> padlocks;
    public Animator chestAnimator;
    public BoundsControl chestBoundsControl;
    public GameObject riddleObject;

    private char[] currentCombination;

    private void Awake()
    {
        chestBoundsControl.enabled = false;

        currentCombination = new char[combination.Length];
        for (int i = 0; i < padlocks.Count; i++) currentCombination[i] = padlocks[i].charsOrder[0];
    }

    public void UpdateCombination()
    {
        for (int i = 0; i < padlocks.Count; i++) currentCombination[i] = padlocks[i].GetCharSelected();
        CheckCombination();
    }

    public void CheckCombination()
    {
        for (int i = 0; i < currentCombination.Length; i++)
        {
            if (currentCombination[i] != combination[i]) return;
        }

        foreach (PadlockCombination padlockCombination in padlocks) padlockCombination.StopManipulation();
        chestAnimator.SetTrigger("Open");
        riddleObject.SetActive(false);
    }

    public void OpeningAnimationEnded()
    {
        chestAnimator.enabled = false;
        chestBoundsControl.enabled = true;
    }
}
