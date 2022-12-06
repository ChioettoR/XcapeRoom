using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryObject", menuName = "ScriptableObjects/InventoryObject", order = 1)]
public class InventoryObject : ScriptableObject
{
    public GameObject prefab;
    public Sprite icon;
}
