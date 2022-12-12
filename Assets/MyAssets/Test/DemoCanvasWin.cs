using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCanvasWin : MonoBehaviour
{
    public int puzzlesToSolve;
    public GameObject canvas;

    private int puzzlesResolved;

    public void PuzzleSolved()
    {
        puzzlesResolved++;
        if (puzzlesResolved == puzzlesToSolve) canvas.SetActive(true);
    }
}
