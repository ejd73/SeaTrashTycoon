using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField]
    private UIInventoryItem itemPrefab;

    [SerializeField]
    private RectTransform contentPanel;

    List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

    public void InitializeInventoryUI(int inventorySize){
        for(int i = 0; i < inventorySize; i++){
            UIInventoryItem UIItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            UIItem.transform.SetParent(contentPanel);
            listOfUIItems.Add(UIItem);
        }
    }

        public void Show(){
            gameObject.SetActive(true);
        }

        public void Hide(){
            gameObject.SetActive(false);
        }
    }
