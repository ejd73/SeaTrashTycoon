using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import UnityEngine.UI for Scrollbar

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;

    public GameObject[] progressBlocks;   // Array to hold the progress blocks
    public Scrollbar progressBar;         // Reference to the Scrollbar UI

    private float points = 0f;            // Track points (0.5 per trash item collected)
    private int maxProgressBlocks;        // The total number of progress blocks
    private float maxPoints;              // The maximum points before progress resets

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

        // Initialize the progress blocks as inactive
        foreach (GameObject block in progressBlocks)
        {
            block.SetActive(false);
        }

        maxProgressBlocks = progressBlocks.Length;
        maxPoints = (float)maxProgressBlocks; // Points required to fill all progress blocks
        progressBar.value = 0; // Initialize the scrollbar value to 0
    }

    public void CollectTrash()
    {
        // Add 0.5 points for each trash item collected
        points += 0.5f;

        // Calculate the progress block index based on points (only show a block when points are a whole number)
        int blockIndex = Mathf.FloorToInt(points); // Convert points to an integer for block index

        // Ensure that blockIndex is valid and the corresponding progress block hasn't been activated yet
        if (blockIndex >= 0 && blockIndex < progressBlocks.Length)
        {
            // Ensure this block is activated only when points exactly reach the whole number
            if (Mathf.Approximately(points, blockIndex)) // Check if points are exactly a whole number
            {
                // Activate the next progress block
                progressBlocks[blockIndex].SetActive(true);
            }
        }

        // Update the scrollbar progress based on the points collected
        progressBar.value = points / maxPoints;

        // Optional: Reset progress when all blocks are filled
        if (blockIndex >= progressBlocks.Length)
        {
            Debug.Log("All progress blocks filled! Resetting progress...");
            ResetProgress();
        }
    }

    // Reset the progress bar (optional)
    public void ResetProgress()
    {
        points = 0;

        // Deactivate all progress blocks
        foreach (GameObject block in progressBlocks)
        {
            block.SetActive(false);
        }

        // Reset the scrollbar value
        progressBar.value = 0;
    }
}

