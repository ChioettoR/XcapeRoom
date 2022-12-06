using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDescriptionManager : MonoBehaviour
{
    public List<PopUp> popups;
    public AudioSlider audioSlider;
    public AudioClip fullAudioClip;

    private void Awake()
    {
        ResetAllPopUps();
    }

    public void PlayFullAudio()
    {
        audioSlider.ShowSlider(fullAudioClip);
        StartCoroutine(FullAudioCoroutine());
    }

    public void StopFullAudio()
    {
        audioSlider.HideSlider();
        StopAllCoroutines();
    }

    IEnumerator FullAudioCoroutine()
    {
        while (true)
        {
            float audioSourceTime = audioSlider.audioSource.time;

            for (int i = popups.Count - 1; i >= 0; i--)
            {
                if (audioSourceTime >= popups[i].showTime)
                {
                    ResetAllPopUps();
                    popups[i].popUpObject.SetActive(true);
                    break;
                }
            }

            yield return null;
        }
    }

    private void ResetAllPopUps()
    {
        foreach (PopUp pup in popups) pup.popUpObject.SetActive(false);
    }
}

[System.Serializable]
public class PopUp
{
    public GameObject popUpObject;
    public float showTime;
}
