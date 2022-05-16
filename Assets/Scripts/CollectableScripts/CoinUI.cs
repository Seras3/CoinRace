using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    private TextMeshProUGUI _coinsText;
    
    void Start()
    {
        _coinsText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void UpdateUI(PlayerInventory playerInventory, int maxCoins)
    {
        _coinsText.text = playerInventory.Coins + "/" + maxCoins;
    }
}
