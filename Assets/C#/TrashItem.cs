using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : MonoBehaviour
{
    void OnMouseDown()
    {
        // Call a method to update the progress bar in the GameManager
        GameManager1.instance.CollectTrash();

        // Destroy the trash item after collection
        Destroy(gameObject);
    }
}
