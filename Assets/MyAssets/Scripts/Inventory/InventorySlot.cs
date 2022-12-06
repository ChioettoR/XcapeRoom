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
    private InventoryObject inventoryObject;
    private GameObject instantiatedObject;

    public bool CheckAvailable()
    {
        return available;
    }

    public void Click()
    {
        if (available) return;

        if (!instantiatedObject)
        {
            instantiatedObject = Instantiate(inventoryObject.prefab, inventoryObjectSpawn.transform.position, inventoryObjectSpawn.transform.rotation, inventoryObjectSpawn);
            instantiatedObject.GetComponent<InventoryMovableObject>().SetSlot(this);
        }
        else instantiatedObject.SetActive(true);

        OpenInventoryObjectWindow(true);
    }

    public void HideObject()
    {
        if(instantiatedObject) instantiatedObject.SetActive(false);
    }

    public void SetInventoryObject(InventoryObject inventoryObject)
    {
        this.inventoryObject = inventoryObject;

        slotImage.sprite = inventoryObject.icon;
        slotImage.gameObject.SetActive(true);
        available = false;
    }

    public void RemoveInventoryObject()
    {
        inventoryObject = null;

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
