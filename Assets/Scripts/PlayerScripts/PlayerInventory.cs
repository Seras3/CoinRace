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
            if (_isPlayer1 && GameManagerScript.Player1Wins == SettingsManagerScript.Instance.MaxWins - 1 || 
                !_isPlayer1 && GameManagerScript.Player2Wins == SettingsManagerScript.Instance.MaxWins - 1)
            {
                GameManagerScript.Instance.EndRound(_isPlayer1, UIManagerScript.Instance.EndRoundDelay);
            }
            else
            {
                GameManagerScript.Instance.EndRound(_isPlayer1);
            }
            
        }
    }
}
