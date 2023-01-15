using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAtStartManager : MonoBehaviour
{
    public bool showTutorialOnStart;
    public NewMenuManager menuManager;

    private void Start()
    {
        if (!showTutorialOnStart) return;

        if (!menuManager.gameObject.activeSelf) menuManager.ActiveMenu();
        menuManager.OpenTutorial();
    }
}
