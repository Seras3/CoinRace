using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    
    private static UIManagerScript _instance;

    public static UIManagerScript Instance
    {
        get
        {
            if (_instance is null)
            {
                print("UI MANAGER is NULL");
            }

            return _instance;
        }
    }
    
    private Image _player1HealthImage, _player2HealthImage;

    [SerializeField] private bool isGameScene;

    [SerializeField] private GameObject _pauseScreen, _finishScreen;

    [SerializeField] private Slider _vfxSlider, _musicSlider;

    [SerializeField] private TextMeshProUGUI _roundText;

    [SerializeField] private GameObject _player1Trophy, _player2Trophy;
    public float EndRoundDelay { get; private set; }
    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        if (isGameScene)
        {
            EndRoundDelay = 3;
            _player1HealthImage = GameObject.Find(ObjectNames.PLAYER_1_HEALTH_UI).GetComponent<Image>();
            _player2HealthImage = GameObject.Find(ObjectNames.PLAYER_2_HEALTH_UI).GetComponent<Image>();
        }

        _vfxSlider.value = SettingsManagerScript.Instance.VFXVolume;
        _musicSlider.value = SettingsManagerScript.Instance.MusicVolume;
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

    public void DisplayFinishScreen(bool isPlayer1Winner)
    {
        var message = (isPlayer1Winner ? "BLUE" : "RED") + " has won!";
        _finishScreen.SetActive(true);
        GameObject.Find(ObjectNames.WINNER_MESSAGE_TEXT).GetComponent<TextMeshProUGUI>().text = message;
        
    }

    public void DisplayRound(int round)
    {
        if (round != 2 * SettingsManagerScript.Instance.MaxWins - 1)
        {
            _roundText.text = "Round " + round;
        }
        else
        {
            _roundText.text = "Final Round";
        }
    }

    public void DisplayPlayer1Trophy()
    {
        _player1Trophy.SetActive(true);
    }
    
    public void DisplayPlayer2Trophy()
    {
        _player2Trophy.SetActive(true);
    }
    
    
    public void DisplayPauseScreen()
    {
        _pauseScreen.SetActive(true);
    }

    public void HidePauseScreen()
    {
        _pauseScreen.SetActive(false);
    }

    public void HideFinishScreen()
    {
        _finishScreen.SetActive(false);
    }
}
