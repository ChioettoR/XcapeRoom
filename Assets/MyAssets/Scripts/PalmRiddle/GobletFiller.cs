using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class GobletFiller : MonoBehaviour
{
    public Renderer rend;
    public Interactable gobletInteractable;
    public float fullFillAmount;
    public float emptyFillAmount;
    public float fullTime;

    void Start()
    {
        rend.material.SetFloat("_FillAmount", emptyFillAmount);
    }


    public void Fill()
    {
        StartCoroutine(FillCoroutine());
    }

    IEnumerator FillCoroutine()
    {
        gobletInteractable.enabled = false;
        float time = 0;
        while (time < fullTime)
        {
            time += Time.deltaTime;
            rend.material.SetFloat("_FillAmount", Mathf.Lerp(emptyFillAmount, fullFillAmount, time / fullTime));
            yield return null;
        }
        gobletInteractable.enabled = true;
    }
}
