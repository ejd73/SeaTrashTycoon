using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuControl : MonoBehaviour
{
    public void LoadTutorial()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void LoadMainGamePlay()
    {
        SceneManager.LoadScene("MainGamePlay2");
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene("Menu");
    }
     public void QuitGame()
    {
        Application.Quit();
        // This line is just for testing in the Unity Editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
