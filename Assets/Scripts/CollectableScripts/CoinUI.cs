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
        _coinsText.text = "0/" + SettingsManagerScript.Instance.MaxCoins;
    }

    public void UpdateUI(PlayerInventory playerInventory)
    {
        _coinsText.text = playerInventory.Coins + "/" + SettingsManagerScript.Instance.MaxCoins;
    }
}
