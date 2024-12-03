using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPopupButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        if (CoinManager.instance != null)
        {
            CoinManager.instance.ToggleCoinPopup(); // Show the coin popup
        }
    }
}

