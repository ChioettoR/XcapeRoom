using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image slotImage;
    public GameObject inventoryMenu;
    public GameObject inventoryObjectMenu;
    public Transform inventoryObjectSpawn;

    private bool available = true;
    private CollectableObject collectableObject;
    private InventoryMovableObject inventoryMovableObject;

    public bool CheckAvailable()
    {
        return available;
    }

    public void Click()
    {
        if (available) return;

        collectableObject.transform.parent = inventoryObjectSpawn.transform;
        inventoryMovableObject.ResetPosition();

        inventoryMovableObject.SetSlot(this);

        collectableObject.gameObject.SetActive(true);

        collectableObject.ActiveCollect(false);
        inventoryMovableObject.ActiveManipulator(true);

        OpenInventoryObjectWindow(true);
    }

    public void HideObject()
    {
        if(collectableObject) collectableObject.gameObject.SetActive(false);
    }

    public void SetInventoryObject(CollectableObject collectableObject)
    {
        this.collectableObject = collectableObject;
        inventoryMovableObject = collectableObject.GetComponent<InventoryMovableObject>();

        slotImage.sprite = collectableObject.sprite;
        slotImage.gameObject.SetActive(true);
        available = false;
    }

    public void RemoveInventoryObject()
    {
        collectableObject = null;
        inventoryMovableObject = null;

        slotImage.sprite = null;
        slotImage.gameObject.SetActive(false);
        available = true;

        OpenInventoryObjectWindow(false);
    }

    private void OpenInventoryObjectWindow(bool open)
    {
        inventoryObjectMenu.SetActive(open);
        inventoryMenu.SetActive(!open);
    }
}
