using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    private Spawner spawner;

    // Method to set the spawner reference
    public void SetSpawner(Spawner spawner)
    {
        this.spawner = spawner;
    }

    void OnMouseDown()
    {
        // Destroy the object when clicked
        GameManager.instance.AddQuizPoints(0.05f); // Add 0.1 points to the progress bar
        Debug.Log("Item clicked: " + gameObject.name); // Debug line
        Destroy(gameObject);

        // Decrement the item count in the spawner
        if (spawner != null)
        {
            spawner.DecrementItemCount();
        }
    }
}

