using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class companyTrigger : MonoBehaviour
{
     public GameObject uiObjectToEnable; // UI to show
     public GameObject uiObjectToDisable; // UI to hide

     public void Start()
     {
          uiObjectToEnable.SetActive(false);
          uiObjectToDisable.SetActive(true);
     }

     private void OnTriggerEnter2D(Collider2D collision)
     {
          Debug.Log("We just collided");
          InventoryManager.Instance.DisplayImpact();

          // Show one UI element and hide the other
          uiObjectToEnable.SetActive(true);
          uiObjectToDisable.SetActive(false);
     }

     private void OnTriggerStay2D(Collider2D collision)
     {
          Debug.Log("We still collided");
     }

     private void OnTriggerExit2D(Collider2D collision)
     {
          // Revert the UI changes when exiting the trigger
          uiObjectToEnable.SetActive(false);
          uiObjectToDisable.SetActive(true);
          Debug.Log("We quit collided");
     }
}
