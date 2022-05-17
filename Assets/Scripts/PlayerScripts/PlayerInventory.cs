using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    private bool _isPlayer1;
    public int Coins { get; private set; }

    public UnityEvent<PlayerInventory> OnCoinCollect;

    void Start()
    {
        _isPlayer1 = gameObject.name == ObjectNames.PLAYER_1;
    }
    public void CollectCoin()
    {
        Coins++;
        OnCoinCollect.Invoke(this);

        if (Coins == SettingsManagerScript.Instance.MaxCoins)
        {
            GameManagerScript.Instance.EndRound(_isPlayer1, UIManagerScript.Instance.EndRoundDelay);
        }
    }
}
