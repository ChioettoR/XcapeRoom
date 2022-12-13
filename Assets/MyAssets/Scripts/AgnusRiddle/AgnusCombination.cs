using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class AgnusCombination : MonoBehaviour
{
    public int correctPiecesNumber;
    public List<Interactable> collectablePieces;
    public GameObject map;

    //DEMO
    public DemoCanvasWin demoCanvasWin;

    private int currentCorrectPiecesNumber;

    public void Correct()
    {
        currentCorrectPiecesNumber++;
        Debug.Log("CORRECT: " + currentCorrectPiecesNumber);

        if (currentCorrectPiecesNumber == correctPiecesNumber)
        {
            map.SetActive(true);
            foreach (Interactable interactable in collectablePieces) interactable.enabled = false;

            //Da togliere
            demoCanvasWin.PuzzleSolved();
        }
    }

    public void CorrectRemoved()
    {
        currentCorrectPiecesNumber--;
        Debug.Log("CORRECT: " + currentCorrectPiecesNumber);
    }
}
