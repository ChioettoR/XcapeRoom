using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class AgnusCombination : MonoBehaviour
{
    public int correctPiecesNumber;
    public List<Interactable> collectablePieces;
    public Animator drawerAC;

    private int currentCorrectPiecesNumber;

    public void Correct()
    {
        currentCorrectPiecesNumber++;

        if (currentCorrectPiecesNumber == correctPiecesNumber)
        {
            foreach (Interactable interactable in collectablePieces) interactable.enabled = false;
            drawerAC.SetTrigger("OpenDrawer");
        }
    }

    public void CorrectRemoved()
    {
        currentCorrectPiecesNumber--;
    }
}
