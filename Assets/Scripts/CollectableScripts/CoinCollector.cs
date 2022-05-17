using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.CollectCoin();
            SoundManagerScript.Instance.CoinCollectSoundPlay();
            gameObject.SetActive(false);
            
            if (playerInventory.Coins != SettingsManagerScript.Instance.MaxCoins)
            {
                gameObject.GetComponent<CoinRespawner>().Respawn();
            }
        }
    }
}
