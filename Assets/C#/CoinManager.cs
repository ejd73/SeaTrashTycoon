using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // Singleton to allow easy access

    private int coinCount = 0; // To track collected coins

    [Header("UI Elements")]
    public GameObject coinPopup; // The popup canvas
    public TextMeshProUGUI coinCountText; // Text to display coin count

    void Awake()
    {
        // Ensure there's only one instance of this class
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Hide the popup initially
        if (coinPopup != null)
        {
            coinPopup.SetActive(false);
        }
    }

    // Method to increment coin count when a coin is collected
    public void CollectCoin()
    {
        coinCount++; // Increment coin count
        Debug.Log("Coins Collected: " + coinCount);
    }

    // Method to display the popup and update the coin count text
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
    
    // Method to award coins based on the quiz score
    public void AwardQuizCoins(int score, int totalQuestions)
    {
        int awardedCoins = Mathf.FloorToInt(score / 2f); // Calculate coins based on half the correct answers
        coinCount += awardedCoins; // Add awarded coins to the total count
        UpdateCoinPopup(); // Update the popup or UI if needed
        Debug.Log($"Awarded {awardedCoins} coins for quiz performance! Total coins: {coinCount}");
    }


    private void UpdateCoinPopup()
    {
        if (coinCountText != null)
        {
            coinCountText.text = "" + coinCount; // Update coin count
        }

        // Optionally update levels later
        //if (levelCountText != null)
        //{
            //levelCountText.text = "Level: " + Mathf.FloorToInt(points / 10); // Example level logic
       //}
    }
}

