using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadlockManager : MonoBehaviour
{
    public string combination;
    public List<PadlockCombination> padlocks;

    private char[] currentCombination;

    private void Awake()
    {
        currentCombination = new char[combination.Length];
        for (int i = 0; i < padlocks.Count; i++) currentCombination[i] = padlocks[i].charsOrder[0];
    }

    public void UpdateCombination()
    {
        for (int i = 0; i < padlocks.Count; i++)
        {
            currentCombination[i] = padlocks[i].GetCharSelected();
            Debug.Log(currentCombination[i]);
        }
        CheckCombination();
    }

    public void CheckCombination()
    {
        for (int i = 0; i < currentCombination.Length; i++)
        {
            if (currentCombination[i] != combination[i]) return;
        }
        Debug.Log("CORRECT");
    }
}
