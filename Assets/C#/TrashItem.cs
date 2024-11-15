using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : MonoBehaviour
{
    // Reference to the LevelProgress script
    public LevelProgress LevelProgress;

    void OnMouseDown()
    {
        // Handle trash collection logic
        if (LevelProgress != null)
        {
            LevelProgress.CollectTrash();  // Update progress
        }

        // Destroy this item
        Destroy(gameObject);
    }
}
