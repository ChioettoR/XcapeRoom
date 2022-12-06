using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class AudioSlider : MonoBehaviour
{
    public SpriteRenderer playButton;
    public AudioSource audioSource;
    public Sprite playSprite;
    public Sprite pauseSprite;
    public PinchSlider pinchSlider;
    public Interactable playButtonInteractable;

    private bool isPaused = true;
    private bool amMovingSlider = false;

    private void Awake()
    {
        pinchSlider.gameObject.SetActive(false);
    }

    public void ShowSlider(AudioClip audioClip)
    {
        Reset();
        pinchSlider.gameObject.SetActive(true);
        audioSource.clip = audioClip;
    }

    public void HideSlider()
    {
        Reset();
        pinchSlider.gameObject.SetActive(false);
    }

    public void PlayAudio()
    {
        isPaused = !isPaused;

        if (!isPaused)
        {
            amMovingSlider = false;
            playButton.sprite = pauseSprite;
            audioSource.Play();
        }
        else
        {
            amMovingSlider = true;
            playButton.sprite = playSprite;
            audioSource.Pause();
        }
    }

    public void AmMovingSlider(bool amMovingSlider)
    {
        this.amMovingSlider = amMovingSlider;
    }

    private void Update()
    {
        if (!pinchSlider.gameObject.activeSelf || audioSource.clip == null) return;

        float audioPercentage = audioSource.time / audioSource.clip.length;
        if (!amMovingSlider)
        {
            pinchSlider.SliderValue = audioPercentage;
        }
        else
        {
            audioSource.time = Mathf.Min(pinchSlider.SliderValue * audioSource.clip.length, audioSource.clip.length - 0.01f);
        }

        if (pinchSlider.SliderValue == 1) Reset();
    }

    private void Reset()
    {
        amMovingSlider = true;

        playButtonInteractable.IsToggled = false;
        audioSource.time = 0;
        pinchSlider.SliderValue = 0;
        playButton.sprite = playSprite;
        isPaused = true;
    }
}
