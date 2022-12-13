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

    private void Awake()
    {
        pinchSlider.gameObject.SetActive(false);
        pinchSlider.enabled = true;
    }

    public void ShowSlider(AudioClip audioClip)
    {
        Reset();
        pinchSlider.gameObject.SetActive(true);
        audioSource.clip = audioClip;

        playButtonInteractable.IsToggled = true;
        PlayAudio();
    }

    public void HideSlider()
    {
        Reset();
        pinchSlider.gameObject.SetActive(false);
    }

    public void PlayAudio()
    {
        pinchSlider.enabled = false;

        playButton.sprite = pauseSprite;
        audioSource.Play();
    }

    public void PauseAudio()
    {
        pinchSlider.enabled = true;

        playButton.sprite = playSprite;
        audioSource.Pause();
    }

    public void SliderMoved()
    {
        if (!gameObject.activeSelf || audioSource.clip == null) return;

        audioSource.time = Mathf.Min(pinchSlider.SliderValue * audioSource.clip.length, audioSource.clip.length - 0.01f);
    }

    private void Update()
    {
        if (!gameObject.activeSelf || audioSource.clip == null) return;

        if (pinchSlider.SliderValue >= 0.99f) Reset();
        else if (audioSource.isPlaying) pinchSlider.SliderValue = audioSource.time / audioSource.clip.length;
    }

    private void Reset()
    {
        pinchSlider.enabled = false;
        playButtonInteractable.IsToggled = false;

        audioSource.Stop();
        audioSource.time = pinchSlider.SliderValue = 0;
        pinchSlider.enabled = true;

        playButton.sprite = playSprite;
    }
}
