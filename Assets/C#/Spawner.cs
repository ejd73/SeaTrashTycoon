using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // The item to spawn
    public GameObject itemPrefab;

    // Max number of items allowed at one time
    public int maxActiveItems = 10;

    // Range for the spawn zone
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    // Spawn interval in seconds
    public float spawnInterval = 3f;

    // Track the current number of active items in the scene
    private int currentActiveItems = 0;

    void Start()
    {
        // Start spawning items at regular intervals
        InvokeRepeating("TrySpawnItem", 2f, spawnInterval);
    }

    void TrySpawnItem()
    {
        // Only spawn if the number of active items is below the limit
        if (currentActiveItems < maxActiveItems)
        {
            SpawnItem();
        }
    }

    void SpawnItem()
    {
        // Generate random position within the specified zone
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 randomPosition = new Vector2(randomX, randomY);

        // Spawn the item at the random position
        GameObject spawnedItem = Instantiate(itemPrefab, randomPosition, Quaternion.identity);

        // Increment the active item count
        currentActiveItems++;

        // Attach the click-to-destroy script to the spawned item
        DestroyOnClick clickScript = spawnedItem.AddComponent<DestroyOnClick>();
        clickScript.SetSpawner(this);  // Pass the spawner reference
    }

    // Method to decrement the active item count when an item is destroyed
    public void DecrementItemCount()
    {
        currentActiveItems--;
    }
}
