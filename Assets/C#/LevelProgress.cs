using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class LevelProgress : MonoBehaviour
{
    // Reference to the Scrollbar UI
    public Scrollbar ProgressBar;

    // Number of trash items collected
    private int trashCollected = 0;

    // Max number of sections in the progress bar (10 sections)
    private int maxSections = 10;

    // Trash items needed to fill one section (3 items per section)
    private int trashPerSection = 3;

    // Current progress level
    private int currentProgress = 0;

    void Start()
    {
        // Initialize the progress bar (set it to 0)
        ProgressBar.value = 0;
    }

    // Call this function whenever an item of trash is collected
    public void CollectTrash()
    {
        // Increment the trash collected count
        trashCollected++;

        // Check if 3 trash items have been collected
        if (trashCollected >= trashPerSection)
        {
            // Increment progress (1 section filled)
            currentProgress++;

            // Calculate the value for the Scrollbar (from 0 to 1)
            ProgressBar.value = (float)currentProgress / maxSections;

            // Reset the trash collected count
            trashCollected = 0;

            // Check if the progress bar is full
            if (currentProgress >= maxSections)
            {
                // Reset the progress bar when full
                currentProgress = 0;
                ProgressBar.value = 0;

                // Optionally, trigger an event when the bar is full, like awarding points
                Debug.Log("Progress bar full! Resetting...");
            }
        }
    }
}

