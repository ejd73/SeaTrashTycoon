using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import the TextMeshPro namespace

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;

    public GameObject[] progressBlocks;
    public Scrollbar progressBar;
    public TextMeshProUGUI resetCounterText; // Use TextMeshProUGUI instead of Text

    private float points = 0f;
    private int maxProgressBlocks;
    private float maxPoints;
    private int resetCounter = 1;

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

        // Initialize the reset counter display
        UpdateResetCounterUI();
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

        // Increment and display reset counter
        resetCounter++;
        UpdateResetCounterUI();
    }

    void UpdateResetCounterUI()
    {
        if (resetCounterText != null)
        {
            resetCounterText.text =  resetCounter.ToString();
        }
    }
}
