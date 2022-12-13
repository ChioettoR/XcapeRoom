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
        else Debug.Log("ERROR");
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
