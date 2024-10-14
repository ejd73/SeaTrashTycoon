using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding with the coin is the player
        if (other.CompareTag("Player"))
        {
            // Call a method to update the progress bar
            GameManager.instance.CollectCoin();

            // Destroy the coin after collection
            Destroy(gameObject);
        }
    }
}
