using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class AgnusCombination : MonoBehaviour
{
    public int correctPiecesNumber;
    public List<Interactable> collectablePieces;

    private int currentCorrectPiecesNumber;

   public void Correct()
    {
        currentCorrectPiecesNumber++;
        if (currentCorrectPiecesNumber == correctPiecesNumber)
        {
            Debug.Log("Correct");
            foreach (Interactable interatable in collectablePieces) interatable.enabled = false;
        }
    }

    public void CorrectRemoved()
    {
        currentCorrectPiecesNumber--;
    }
}