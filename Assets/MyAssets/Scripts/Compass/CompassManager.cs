using System.Collections;
using System.Collections.Generic;
using NRKernal;
using UnityEngine;
using UnityEngine.UI;

public class CompassManager : MonoBehaviour
{
    public GameObject compass;
    public Image showCompassButton;
    public NRButton nRButton;

    public Sprite showCompassButtonEnabled;
    public Sprite showCompassButtonDisabled;

    private bool compassWasActiveBeforeHide = true;

    private void Awake()
    {
        HideButton();
    }

    public void HideButton()
    {
        showCompassButton.gameObject.SetActive(false);

        compassWasActiveBeforeHide = compass.activeSelf;
        compass.SetActive(false);
    }

    public void ShowButton()
    {
        showCompassButton.gameObject.SetActive(true);

        if(compassWasActiveBeforeHide) compass.SetActive(true);
        compassWasActiveBeforeHide = false;
    }

    public void ShowCompassButtonClicked()
    {
        compass.SetActive(!compass.activeSelf);

        showCompassButton.sprite = compass.activeSelf ? showCompassButtonEnabled : showCompassButtonDisabled;
        nRButton.ImageHover = nRButton.ImageNormal = compass.activeSelf ? showCompassButtonEnabled : showCompassButtonDisabled;
    }
}
