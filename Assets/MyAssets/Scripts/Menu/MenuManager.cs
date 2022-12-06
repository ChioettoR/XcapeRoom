using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void ActiveMenu()
    {
        if (!gameObject.activeSelf) MoveMenuNearCamera();

        gameObject.SetActive(!gameObject.activeSelf);
    }

    private void MoveMenuNearCamera()
    {

    }
}
