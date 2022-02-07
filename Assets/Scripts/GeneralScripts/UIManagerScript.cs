using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    private Image _player1HealthImage, _player2HealthImage;
    void Start()
    {
        _player1HealthImage = GameObject.Find(ObjectNames.PLAYER_1_HEALTH_UI).GetComponent<Image>();
        _player2HealthImage = GameObject.Find(ObjectNames.PLAYER_2_HEALTH_UI).GetComponent<Image>();
    }

    public void DisplayHealthUI(bool isPlayer1, float value)
    {
        value /= 100f;
        
        if (value < 0f)
        {
            value = 0;
            print("Warning: Health value < 0");
        }

        if (value > 1f)
        {
            value = 1;
            print("Warning: Health value > 1");
        }
        
        if (isPlayer1)
        {
            _player1HealthImage.fillAmount = value;
        }
        else
        {
            _player2HealthImage.fillAmount = value;
        }
    }
}
