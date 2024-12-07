using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneButtons : MonoBehaviour
{
    // Method to load the main menu
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu"); // Replace "MainMenu" with the exact name of your main menu scene
    }

    // Method to quit the game
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();

        // Log to the console for testing in the editor (Optional)
        Debug.Log("Game is quitting...");
    }
}
