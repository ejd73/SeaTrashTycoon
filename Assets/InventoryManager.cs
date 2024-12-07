using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    // Static instance of the InventoryManager
    public static InventoryManager Instance { get; private set; }

    public TMP_Text inventoryList; // Existing inventory display
    public TMP_Text impactText;   // New TMP_Text for impact display

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

    // Logs the entire inventory (for debugging purposes)
public void LogInventory()
{
    foreach (var item in inventory)
    {
        Debug.Log($"Item: {item.Key}, Quantity: {item.Value}");
    }
}

// Display the entire inventory in the inventoryList TMP object
public void DisplayInventory()
{
    if (inventoryList != null)
    {
        string inventoryDisplay = "";

        foreach (var item in inventory)
        {
            inventoryDisplay += $"{item.Key}: {item.Value}\n";
        }

        inventoryList.text = inventoryDisplay;
    }
}

    // Method to display environmental impact in a separate TMP_Text
    public void DisplayImpact()
    {

        Debug.Log("DisplayImpact called."); 

        // Start with an introductory message
        string impactDisplay = "";

        // Dictionary to map items to their environmental benefits
        Dictionary<string, (string impact, int fishSaved)> itemDetails = new Dictionary<string, (string, int)>()
        {
            { "empty wrapper", ("Reduced microplastic pollution in the ocean", 5) },
            { "sodaCo bottle", ("Prevented fish from dying to microplastics.", 10) },
            { "sodaCo can", ("Reduced risks to marine life from sharp edges", 8) },
            { "plastic bag", ("Prevented choking hazards for marine animals", 12) },
            { "old bobber", ("Removed entanglement risk for marine creatures", 6) },
            { "glass bottle", ("Reduced habitat destruction from broken glass", 7) },
            { "sodaCo mug", ("Reduced ocean floor littering", 15) }
        };

        // Track total fish saved
        int totalFishSaved = 0;

        // Loop through the inventory and add details to the display
        foreach (var item in inventory)
        {
            if (itemDetails.ContainsKey(item.Key))
            {
                string impact = itemDetails[item.Key].impact;
                int fishSavedPerItem = itemDetails[item.Key].fishSaved;
                int fishSavedTotal = fishSavedPerItem * item.Value;

                impactDisplay += $"{item.Key} (x{item.Value}): {impact}. Fish Saved: {fishSavedTotal}\n";

                totalFishSaved += fishSavedTotal;
            }
            else
            {
                // Handle unexpected items gracefully
                impactDisplay += $"{item.Key} (x{item.Value}): No data available.\n";
            }
        }

        // Add a summary at the end
        impactDisplay += $"\nTotal Fish Saved: {totalFishSaved}";

        // Update the new TextMeshPro object
        if (impactText != null)
        {
            Debug.Log($"Impact Text Content: {impactDisplay}");
            impactText.text = impactDisplay;
        }
        else
        {
            Debug.LogWarning("ImpactText TMP object is not assigned.");
        }
    }
}
