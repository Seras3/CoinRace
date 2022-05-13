using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    private static InputManagerScript _instance;

    public static InputManagerScript Instance
    {
        get
        {
            if (_instance is null)
            {
                print("INPUT MANAGER is NULL");
            }

            return _instance;
        }
    }

    [SerializeField] private TMP_InputField _p1Up, _p1Down, _p1Left, _p1Right, _p1Punch, _p1Kick;
    [SerializeField] private TMP_InputField _p2Up, _p2Down, _p2Left, _p2Right, _p2Punch, _p2Kick;
    [SerializeField] private TMP_InputField _pause;

    void Start()
    {
        _p1Up.text = Storage.Keys[PlayerPrefsKeys.P1_UP];
        _p1Down.text = Storage.Keys[PlayerPrefsKeys.P1_DOWN];
        _p1Left.text = Storage.Keys[PlayerPrefsKeys.P1_LEFT];
        _p1Right.text = Storage.Keys[PlayerPrefsKeys.P1_RIGHT];
        _p1Punch.text = Storage.Keys[PlayerPrefsKeys.P1_PUNCH];
        _p1Kick.text = Storage.Keys[PlayerPrefsKeys.P1_KICK];
        
        _p2Up.text = Storage.Keys[PlayerPrefsKeys.P2_UP];
        _p2Down.text = Storage.Keys[PlayerPrefsKeys.P2_DOWN];
        _p2Left.text = Storage.Keys[PlayerPrefsKeys.P2_LEFT];
        _p2Right.text = Storage.Keys[PlayerPrefsKeys.P2_RIGHT];
        _p2Punch.text = Storage.Keys[PlayerPrefsKeys.P2_PUNCH];
        _p2Kick.text = Storage.Keys[PlayerPrefsKeys.P2_KICK];

        _pause.text = Storage.Keys[PlayerPrefsKeys.PAUSE];
    }

    void Update()
    {
        if (GameManagerScript.Instance.State == GameState.MENU || GameManagerScript.Instance.State == GameState.PAUSE)
        {
            // Player1
            if (_p1Up.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.Player1Controls.UpdateKey(PlayerPrefsKeys.P1_UP, _p1Up.GetComponent<DetectKey>().Key);
                _p1Up.GetComponent<DetectKey>().FinishUpdate();
            }
            
            if (_p1Down.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.Player1Controls.UpdateKey(PlayerPrefsKeys.P1_DOWN, _p1Down.GetComponent<DetectKey>().Key);
                _p1Down.GetComponent<DetectKey>().FinishUpdate();
            }
            
            if (_p1Left.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.Player1Controls.UpdateKey(PlayerPrefsKeys.P1_LEFT, _p1Left.GetComponent<DetectKey>().Key);
                _p1Left.GetComponent<DetectKey>().FinishUpdate();
            }
            
            if (_p1Right.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.Player1Controls.UpdateKey(PlayerPrefsKeys.P1_RIGHT, _p1Right.GetComponent<DetectKey>().Key);
                _p1Right.GetComponent<DetectKey>().FinishUpdate();
            }
            
            if (_p1Punch.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.Player1Controls.UpdateKey(PlayerPrefsKeys.P1_PUNCH, _p1Punch.GetComponent<DetectKey>().Key);
                _p1Punch.GetComponent<DetectKey>().FinishUpdate();
            }
            
            if (_p1Kick.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.Player1Controls.UpdateKey(PlayerPrefsKeys.P1_KICK, _p1Kick.GetComponent<DetectKey>().Key);
                _p1Kick.GetComponent<DetectKey>().FinishUpdate();
            }
            
            // Player2
            if (_p2Up.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.Player2Controls.UpdateKey(PlayerPrefsKeys.P2_UP, _p2Up.GetComponent<DetectKey>().Key);
                _p2Up.GetComponent<DetectKey>().FinishUpdate();
            }
            
            if (_p2Down.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.Player2Controls.UpdateKey(PlayerPrefsKeys.P2_DOWN, _p2Down.GetComponent<DetectKey>().Key);
                _p2Down.GetComponent<DetectKey>().FinishUpdate();
            }
            
            if (_p2Left.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.Player2Controls.UpdateKey(PlayerPrefsKeys.P2_LEFT, _p2Left.GetComponent<DetectKey>().Key);
                _p2Left.GetComponent<DetectKey>().FinishUpdate();
            }
            
            if (_p2Right.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.Player2Controls.UpdateKey(PlayerPrefsKeys.P2_RIGHT, _p2Right.GetComponent<DetectKey>().Key);
                _p2Right.GetComponent<DetectKey>().FinishUpdate();
            }
            
            if (_p2Punch.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.Player2Controls.UpdateKey(PlayerPrefsKeys.P2_PUNCH, _p2Punch.GetComponent<DetectKey>().Key);
                _p2Punch.GetComponent<DetectKey>().FinishUpdate();
            }
            
            if (_p2Kick.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.Player2Controls.UpdateKey(PlayerPrefsKeys.P2_KICK, _p2Kick.GetComponent<DetectKey>().Key);
                _p2Kick.GetComponent<DetectKey>().FinishUpdate();
            }
            
            // Pause
            if (_pause.GetComponent<DetectKey>().HasKey)
            {
                SettingsManagerScript.Instance.UpdateKey(PlayerPrefsKeys.PAUSE, _pause.GetComponent<DetectKey>().Key);
                _pause.GetComponent<DetectKey>().FinishUpdate();
            }
        }
    }

}
