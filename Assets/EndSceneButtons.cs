using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneButtons : MonoBehaviour
{
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
