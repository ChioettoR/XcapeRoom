using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;

public class DetailsManager : MonoBehaviour
{
    public List<Detail> details;
    public List<Image> detailIcons;
    public Image focusImage;
    public AudioSlider audioSlider;
    public AudioClip fullAudioClip;

    private Dictionary<int, Detail> detailsDictionary;

    public void PlayFullAudio()
    {
        ShowDetailIcons(false);
        focusImage.gameObject.SetActive(true);

        audioSlider.ShowSlider(fullAudioClip);
        StartCoroutine(FullAudioCoroutine());
    }

    public void StopFullAudio()
    {
        ShowDetailIcons(true);
        focusImage.gameObject.SetActive(false);

        audioSlider.HideSlider();
        StopAllCoroutines();
    }

    public void ShowDetailIcons(bool active)
    {
        foreach (Image image in detailIcons) image.gameObject.SetActive(active);
    }

    IEnumerator FullAudioCoroutine()
    {
        while (true)
        {
            float audioSourceTime = audioSlider.audioSource.time;

            for (int i = details.Count - 1; i >= 0; i--)
            {
                if (audioSourceTime >= details[i].showTime)
                {
                    focusImage.sprite = details[i].sprite;
                    break;
                }
            }

            yield return null;
        }
    }

    private void Awake()
    {
        InitializeDictionary();
        focusImage.gameObject.SetActive(false);
    }

    private void InitializeDictionary()
    {
        detailsDictionary = new Dictionary<int, Detail>();

        foreach(Detail detail in details)
        {
            detailsDictionary.Add(detail.detailID, detail);
        }
    }

    public void ShowDetail(int ID)
    {
        focusImage.gameObject.SetActive(true);

        if (detailsDictionary.TryGetValue(ID, out Detail detail))
        {
            audioSlider.ShowSlider(detail.audioClip);
            focusImage.sprite = detail.sprite;
        }
    }
}

[System.Serializable]
public class Detail
{
    public Sprite sprite;
    public int detailID;
    public AudioClip audioClip;
    public float showTime;
}
