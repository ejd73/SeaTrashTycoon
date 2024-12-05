using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string name;
    public string description;
    public int score;

    private void OnMouseDown()
    {
        InventoryManager.Instance.AddItem(name);
        InventoryManager.Instance.LogInventory();
        InventoryManager.Instance.DisplayInventory();
        Destroy(gameObject);
    }
}
