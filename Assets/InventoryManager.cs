using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    // Static instance of the InventoryManager
    public static InventoryManager Instance { get; private set; }
    public TMP_Text inventoryList;

    // Dictionary to hold inventory items and their quantities
    private Dictionary<string, int> inventory;

    // Called when the script instance is being loaded
    private void Awake()
    {
        // Ensure only one instance of InventoryManager exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }

        // Initialize the inventory
        inventory = new Dictionary<string, int>();
    }

    // Adds an item to the inventory
    public void AddItem(string itemName, int quantity = 1)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName] += quantity;
        }
        else
        {
            inventory[itemName] = quantity;
        }
        Debug.Log($"Added {quantity} of {itemName}. Total: {inventory[itemName]}");
    }

    // Removes an item from the inventory
    public bool RemoveItem(string itemName, int quantity = 1)
    {
        if (inventory.ContainsKey(itemName) && inventory[itemName] >= quantity)
        {
            inventory[itemName] -= quantity;
            Debug.Log($"Removed {quantity} of {itemName}. Remaining: {inventory[itemName]}");

            if (inventory[itemName] == 0)
            {
                inventory.Remove(itemName); // Remove item if quantity is zero
            }
            return true;
        }
        else
        {
            Debug.Log($"Cannot remove {quantity} of {itemName}. Not enough in inventory.");
            return false;
        }
    }

    // Checks if an item exists in the inventory
    public bool HasItem(string itemName)
    {
        return inventory.ContainsKey(itemName);
    }

    // Gets the quantity of a specific item
    public int GetItemQuantity(string itemName)
    {
        return inventory.ContainsKey(itemName) ? inventory[itemName] : 0;
    }

    // Logs the entire inventory (for debugging purposes)
    public void LogInventory()
    {
        foreach (var item in inventory)
        {
            Debug.Log($"Item: {item.Key}, Quantity: {item.Value}");
        }
    }

    // Display the entire inventory
    public void DisplayInventory()
    {
        // Start with the "Collected:" text
        string inventoryDisplay = "";
        
        foreach (var item in inventory)
        {
            inventoryDisplay += "" + item.Key + ": " + item.Value + "\n";
        }
        
        inventoryList.text = inventoryDisplay;
    }
}