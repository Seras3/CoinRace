using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int Coins { get; private set; }

    public UnityEvent<PlayerInventory, int> OnCoinCollect; 
    public void CollectCoin()
    {
        Coins++;
        OnCoinCollect.Invoke(this, SettingsManagerScript.Instance.MaxCoins);

        if (Coins == SettingsManagerScript.Instance.MaxCoins)
        {
            GameManagerScript.Instance.EndRound(gameObject.name == ObjectNames.PLAYER_1);
        }
    }
}
