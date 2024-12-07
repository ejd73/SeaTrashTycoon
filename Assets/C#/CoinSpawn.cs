using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public static CoinSpawn instance;

    public GameObject coinPrefab; // Prefab for the coin object
    public List<Vector3> originalCoinPositions; // Store the original positions of the coins
    public float spawnRadius = 2f; // Maximum distance to spawn coins from their original positions
    public float spawnInterval = 50f; // Interval for spawning new coins

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    public void CollectCoin()
    {
        // Handle coin collection logic (increment count, update UI, etc.)
        Debug.Log("Coin collected!");
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            foreach (Vector3 originalPosition in originalCoinPositions)
            {
                Vector2 randomOffset = new Vector2(
                    Random.Range(-spawnRadius, spawnRadius),
                    Random.Range(-spawnRadius, spawnRadius)
                );

                Vector3 newSpawnPosition = originalPosition + (Vector3)randomOffset;

                // Instantiate a new coin at the calculated position
                Instantiate(coinPrefab, newSpawnPosition, Quaternion.identity);
            }
        }
    }
}
