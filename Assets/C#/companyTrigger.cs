using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class companyTrigger : MonoBehaviour
{


     public GameObject uiObject;
     public void Start()
     {
          uiObject.SetActive(false);
     }
     private void OnTriggerEnter2D()
     {
          Debug.Log("We just collided");
          InventoryManager.Instance.DisplayImpact();
          uiObject.SetActive(true);
     }

     private void OnTriggerStay2D()
     {
          Debug.Log("We still collided");
     }

     private void OnTriggerExit2D()
     {

          uiObject.SetActive(false);
          Debug.Log("We quit collided");
     }
}

