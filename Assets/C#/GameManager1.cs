using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import the TextMeshPro namespace
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;

    public GameObject[] progressBlocks;
    public Scrollbar progressBar;
    public TextMeshProUGUI resetCounterText; // TextMeshProUGUI to display the reset counter
    public TextMeshProUGUI levelTitleText; // TextMeshProUGUI to display the player's level title
    private float points = 0f;
    private int maxProgressBlocks;
    private float maxPoints;
    private int resetCounter = 1;

    // Titles to display as the player levels up
    private string[] levelTitles = {
        "Intern", 
        "Junior Cleaner", 
        "Beach Guardian", 
        "Sustainability Specialist", 
        "Ocean Protector", 
        "Environmental Champion", 
        "Eco Warrior"
    };

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (GameObject block in progressBlocks)
        {
            block.SetActive(false);
        }

        maxProgressBlocks = progressBlocks.Length;
        maxPoints = (float)maxProgressBlocks;
        progressBar.value = 0;

        // Initialize the reset counter display and level title
        UpdateResetCounterUI();
        UpdateLevelTitle();
    }

    public void CollectTrash()
    {
        points += 0.5f;
        int blockIndex = Mathf.FloorToInt(points);

        if (blockIndex >= 0 && blockIndex < progressBlocks.Length)
        {
            if (Mathf.Approximately(points, blockIndex))
            {
                progressBlocks[blockIndex].SetActive(true);
            }
        }

        progressBar.value = points / maxPoints;

        if (blockIndex >= progressBlocks.Length)
        {
            ResetProgress();
        }
    }

    public void ResetProgress()
    {
        points = 0;

        foreach (GameObject block in progressBlocks)
        {
            block.SetActive(false);
        }

        progressBar.value = 0;

        // Increment and display reset counter and level title
        resetCounter++;
        UpdateResetCounterUI();
        UpdateLevelTitle();
    }

    void UpdateResetCounterUI()
    {
        if (resetCounterText != null)
        {
            resetCounterText.text = resetCounter.ToString();
        }
    }

public string endSceneName = "EndScene"; // Set this in the Inspector to match your scene name
    void UpdateLevelTitle()
    {
        // Calculate the player's level based on the resetCounter
        int levelIndex = Mathf.Min(resetCounter - 1, levelTitles.Length - 1); // Ensure it doesn't exceed the array bounds
        if (levelTitleText != null)
        {
            levelTitleText.text = levelTitles[levelIndex];
        }

        // Check if the player has reached level 7 (index 6)
        if (resetCounter >= 7) 
        {
            Debug.Log("Game should end now!");
            // Call method to end the game
            EndGame();
        }
    }

    

    void EndGame()
    {
        Debug.Log($"Attempting to load scene: {endSceneName}");
        SceneManager.LoadScene(endSceneName);
    }


}
