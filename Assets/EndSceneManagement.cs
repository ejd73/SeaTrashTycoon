using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndSceneManagement : MonoBehaviour
{
    public TextMeshProUGUI impactTextDisplay; // Drag your TMP text object here in the Inspector

    void Start()
    {
        // Ensure the impact text is displayed when the end scene loads
        if (impactTextDisplay != null && InventoryManager.Instance != null)
        {
            // Call DisplayImpact to populate the text
            InventoryManager.Instance.impactText = impactTextDisplay;
            InventoryManager.Instance.DisplayImpact();
        }
        else
        {
            Debug.LogWarning("Impact text display or InventoryManager is not set up correctly.");
        }
    }
}
