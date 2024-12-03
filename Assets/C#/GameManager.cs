using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] progressBlocks; // Array to hold the progress blocks
    private float points = 0f; // Track points (0.5 per coin or quiz score)
    public GameObject coinPopup; // The popup canvas for coins and levels
    private int totalCoinsCollected = 0; // Track the total number of coins collected
    private TextMeshProUGUI coinCountText; // To display coin count
    private TextMeshProUGUI levelCountText; // To display level count (optional, not used yet)

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
        // Find and cache the popup texts using tags
        coinCountText = GameObject.FindGameObjectWithTag("coinCount").GetComponent<TextMeshProUGUI>();
        levelCountText = GameObject.FindGameObjectWithTag("levelCount").GetComponent<TextMeshProUGUI>();

        // Hide the popup initially
        if (coinPopup != null)
        {
            coinPopup.SetActive(false);
        }
    }

    public void CollectCoin()
    {
        AddPoints(0.5f); // Add 0.5 points for each coin collected
    }

    public void AddQuizPoints(float quizPoints)
    {
        AddPoints(quizPoints); // Add quiz points (passed from the QA script)
        totalCoinsCollected++; // Increment the coin count
        UpdateCoinPopup(); // Update the popup text
    }

    private void AddPoints(float additionalPoints)
    {
        points += additionalPoints;

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
    }
    public void ToggleCoinPopup()
    {
        if (coinPopup != null)
        {
            bool isActive = coinPopup.activeSelf; // Check if the popup is currently active
            coinPopup.SetActive(!isActive); // Toggle its state

            if (!isActive)
            {
                UpdateCoinPopup(); // Update the popup text when showing it
            }
        }
    }

    // public void HideCoinPopup()
    // {
    //     if (coinPopup != null)
    //     {
    //         coinPopup.SetActive(false); // Hide the popup
    //     }
    // }

    private void UpdateCoinPopup()
    {
        if (coinCountText != null)
        {
            coinCountText.text = "" + totalCoinsCollected; // Update coin count
        }

        // Optionally update levels later
        //if (levelCountText != null)
        //{
            //levelCountText.text = "Level: " + Mathf.FloorToInt(points / 10); // Example level logic
       //}
    }
    
}





// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class GameManager : MonoBehaviour
// {
//     public static GameManager instance;

//     public GameObject[] progressBlocks; // Array to hold the progress blocks
//     private float points = 0f; // Track points (0.5 per coin)

//     void Awake()
//     {
//         if (instance == null)
//         {
//             instance = this;
//         }
//         else
//         {
//             Destroy(gameObject);
//         }

//         // Initialize the progress blocks as inactive
//         foreach (GameObject block in progressBlocks)
//         {
//             block.SetActive(false);
//         }
//     }

//     public void CollectCoin()
//     {
//         // Add 0.5 points for each coin collected
//         points += 0.5f;

//         // Calculate the progress block index based on points (only show a block when points are a whole number)
//         int blockIndex = Mathf.FloorToInt(points); // Convert points to an integer for block index

//         // Ensure that blockIndex is valid and the corresponding progress block hasn't been activated yet
//         if (blockIndex >= 0 && blockIndex < progressBlocks.Length)
//         {
//             // Ensure this block is activated only when points exactly reach the whole number
//             if (Mathf.Approximately(points, blockIndex)) // Check if points are exactly a whole number
//             {
//                 // Activate the next progress block
//                 progressBlocks[blockIndex].SetActive(true);
//             }
//         }
//     }
// }
