using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndSceneManagement : MonoBehaviour
{
    public TextMeshProUGUI impactTextDisplay; // Drag your TMP text object here in the Inspector

    void Start()
    {
        // Ensure the impact text is displayed when the end scene loads
        if (impactTextDisplay != null && InventoryManager.Instance != null)
        {
            // Call DisplayImpact to populate the text
            InventoryManager.Instance.impactText = impactTextDisplay;
            InventoryManager.Instance.DisplayImpact();
        }
        else
        {
            Debug.LogWarning("Impact text display or InventoryManager is not set up correctly.");
        }
    }

     // Method to load the main menu
    public void LoadMainMenu()
    {
        Debug.Log("Button was clicked!");
        SceneManager.LoadScene("Menu"); 
    }

    // Method to quit the game
    public void QuitGame()
    {
        // Quit the application
        Debug.Log("Button was clicked!");
        Application.Quit();

        // Log to the console for testing in the editor (Optional)
        Debug.Log("Game is quitting...");
    }
}
