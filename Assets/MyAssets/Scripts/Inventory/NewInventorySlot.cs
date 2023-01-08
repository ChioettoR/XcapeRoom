using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewInventorySlot : MonoBehaviour
{
    public Image slotImage;
    public NewMenuManager newMenuManager;

    private bool available = true;
    private NewCollectableObject collectableObject;
    private const float wrongObjectTypeTransitionDuration = 0.1f;
    private const float wrongObjectTypeDuration = 0.05f;
    private bool errorCoroutineRunning = false;

    public bool CheckAvailable()
    {
        return available;
    }

    public void Click()
    {
        if (available || newMenuManager.newInventoryManager.GetSelectedDockZone() == null) return;

        if (newMenuManager.newInventoryManager.GetSelectedDockZone().acceptedObjectsTag.Contains(collectableObject.objectTag))
        {
            newMenuManager.newInventoryManager.GetSelectedDockZone().InsertObject(collectableObject);
            RemoveInventoryObject();
        }
        else if (!errorCoroutineRunning) StartCoroutine(SelectedWrongObjectTypeCoroutine());
    }

    IEnumerator SelectedWrongObjectTypeCoroutine()
    {
        errorCoroutineRunning = true;

        Color initialColor = slotImage.color;

        float time = 0f;
        while (time < wrongObjectTypeTransitionDuration)
        {
            slotImage.color = Color.Lerp(initialColor, Color.red, time / wrongObjectTypeTransitionDuration);
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(wrongObjectTypeDuration);

        time = 0f;
        while (time < wrongObjectTypeTransitionDuration)
        {
            slotImage.color = Color.Lerp(Color.red, initialColor, time / wrongObjectTypeTransitionDuration);
            time += Time.deltaTime;
            yield return null;
        }

        slotImage.color = initialColor;
        errorCoroutineRunning = false;
    }

    public void SetInventoryObject(NewCollectableObject collectableObject)
    {
        this.collectableObject = collectableObject;

        slotImage.sprite = collectableObject.sprite;
        slotImage.gameObject.SetActive(true);
        available = false;
    }

    public void RemoveInventoryObject()
    {
        collectableObject = null;

        slotImage.sprite = null;
        slotImage.gameObject.SetActive(false);
        available = true;

        newMenuManager.ActiveMenu();
    }
}
