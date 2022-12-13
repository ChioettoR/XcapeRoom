using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class NewMenuManager : MonoBehaviour
{
    public NewInventoryManager newInventoryManager;
    public List<GameObject> windows;
    public Interactable pinInteractable;
    public FollowMeToggle followMeToggle;

    public GameObject mainMenuWindow;
    public GameObject inventoryWindow;
    //public GameObject tutorialWindow;

    public void ActiveMenu()
    {
        if (pinInteractable.IsToggled)
        {
            pinInteractable.IsToggled = false;
            followMeToggle.ToggleFollowMeBehavior();
        }

        OpenMainMenu();
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void CloseInventoryAndOpenMainMenu()
    {
        PressableDockZone pressableDockZone = newInventoryManager.GetSelectedDockZone();
        if (pressableDockZone) pressableDockZone.GetInteractable().IsToggled = false;

        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        DeactiveAllWindows();

        mainMenuWindow.SetActive(true);
    }

    public void OpenTutorial()
    {
        //TODO: da implementare

        //DeactiveAllWindows();

        //tutorialWindow.SetActive(true);
    }

    public void OpenInventoryAndActiveSlots(PressableDockZone pressableDockZone)
    {
        gameObject.SetActive(true);

        newInventoryManager.SetSelectedDockZone(pressableDockZone);
        OpenInventory(true);
    }

    public void OpenInventory(bool activeSlots)
    {
        DeactiveAllWindows();

        inventoryWindow.SetActive(true);
        newInventoryManager.ActiveInteractables(activeSlots);
    }

    private void DeactiveAllWindows()
    {
        foreach (GameObject window in windows) window.SetActive(false);
    }
}
