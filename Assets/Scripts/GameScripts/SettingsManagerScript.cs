using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.VFX;

[Serializable]
public class PlayerControls
{
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    
    public KeyCode punch;
    public KeyCode kick;

    public PlayerControls(KeyCode moveUp, KeyCode moveDown, KeyCode moveLeft, KeyCode moveRight, KeyCode punch, KeyCode kick)
    {
        this.moveUp = moveUp;
        this.moveDown = moveDown;
        this.moveLeft = moveLeft;
        this.moveRight = moveRight;

        this.punch = punch;
        this.kick = kick;
    }

    public void UpdateKey(string key, KeyCode value)
    {
        switch (key)
        {
            case PlayerPrefsKeys.P1_UP:
                moveUp = value;
                Storage.SetKey(PlayerPrefsKeys.P1_UP, value.ToString());
                break;
            case PlayerPrefsKeys.P1_DOWN:
                moveDown = value;
                Storage.SetKey(PlayerPrefsKeys.P1_DOWN, value.ToString());
                break;
            case PlayerPrefsKeys.P1_LEFT:
                moveLeft = value;
                Storage.SetKey(PlayerPrefsKeys.P1_LEFT, value.ToString());
                break;
            case PlayerPrefsKeys.P1_RIGHT:
                moveRight = value;
                Storage.SetKey(PlayerPrefsKeys.P1_RIGHT, value.ToString());
                break;
            case PlayerPrefsKeys.P1_PUNCH:
                punch = value;
                Storage.SetKey(PlayerPrefsKeys.P1_PUNCH, value.ToString());
                break;
            case PlayerPrefsKeys.P1_KICK:
                kick = value;
                Storage.SetKey(PlayerPrefsKeys.P1_KICK, value.ToString());
                break;
            
            case PlayerPrefsKeys.P2_UP:
                moveUp = value;
                Storage.SetKey(PlayerPrefsKeys.P2_UP, value.ToString());
                break;
            case PlayerPrefsKeys.P2_DOWN:
                moveDown = value;
                Storage.SetKey(PlayerPrefsKeys.P2_DOWN, value.ToString());
                break;
            case PlayerPrefsKeys.P2_LEFT:
                moveLeft = value;
                Storage.SetKey(PlayerPrefsKeys.P2_LEFT, value.ToString());
                break;
            case PlayerPrefsKeys.P2_RIGHT:
                moveRight = value;
                Storage.SetKey(PlayerPrefsKeys.P2_RIGHT, value.ToString());
                break;
            case PlayerPrefsKeys.P2_PUNCH:
                punch = value;
                Storage.SetKey(PlayerPrefsKeys.P2_PUNCH, value.ToString());
                break;
            case PlayerPrefsKeys.P2_KICK:
                kick = value;
                Storage.SetKey(PlayerPrefsKeys.P2_KICK, value.ToString());
                break;
        }
    }
    
    public int HorizontalAxis()
    {
        if (Input.GetKey(moveRight))
        {
            return 1;
        }

        if (Input.GetKey(moveLeft))
        {
            return -1;
        }

        return 0;
    }

    public int VerticalAxis()
    {
        if (Input.GetKey(moveUp))
        {
            return 1;
        }

        if (Input.GetKey(moveDown))
        {
            return -1;
        }

        return 0;
    }

    public override string ToString()
    {
        return String.Format("(Up: {0}, Down: {1})", moveUp, moveDown);
    }  
}

public class SettingsManagerScript : MonoBehaviour
{
    private static SettingsManagerScript _instance;
    public static SettingsManagerScript Instance
    {
        get
        {
            if (_instance is null)
            {
                print("SETTINGS MANAGER is NULL");
            }

            return _instance;
        }
    }
    
    public PlayerControls Player1Controls { get; set; }
    public PlayerControls Player2Controls { get; set; }
    public KeyCode PauseGame { get; set; }
    public float MusicVolume { get; set; }
    public float VFXVolume { get; set; }

    public void MusicVolumeControl(Single volume)
    {
        MusicVolume = volume;
        Storage.SetVolume(PlayerPrefsKeys.MUSIC_VOLUME, volume);
    }
    
    public void VFXVolumeControl(Single volume)
    {
        VFXVolume = volume;
        Storage.SetVolume(PlayerPrefsKeys.VFX_VOLUME, volume);
    }

    public void UpdateKey(string key, KeyCode value)
    {
        switch (key)
        {
            case PlayerPrefsKeys.PAUSE:
                PauseGame = value;
                Storage.SetKey(PlayerPrefsKeys.PAUSE, value.ToString());
                break;
        }
        
    }
    
    private void Awake()
    {
        _instance = this;
        
        var storageKeysToIterate = Storage.Keys.ToDictionary(
            entry => entry.Key, 
            entry => entry.Value);
        
        foreach(KeyValuePair<string, string> entry in storageKeysToIterate)
        {
            if (!PlayerPrefs.HasKey(entry.Key))
            {
                // print("SETEAZA:" + entry.Key + " : " + entry.Value);
                PlayerPrefs.SetString(entry.Key, entry.Value);
            }
            else
            {
                // print("ARE: " + entry.Key + " : " + entry.Value);
                Storage.Keys[entry.Key] = PlayerPrefs.GetString(entry.Key);
            }
        }
        
        
        var storageVolumes = Storage.Volumes.ToDictionary(
            entry => entry.Key, 
            entry => entry.Value);
        
        foreach(KeyValuePair<string, float> entry in storageVolumes)
        {
            if (!PlayerPrefs.HasKey(entry.Key))
            {
                // print("SETEAZA:" + entry.Key + " : " + entry.Value);
                PlayerPrefs.SetFloat(entry.Key, entry.Value);
            }
            else
            {
                // print("ARE: " + entry.Key + " : " + entry.Value);
                Storage.Volumes[entry.Key] = PlayerPrefs.GetFloat(entry.Key);
            }
        }
        
        
        Player1Controls = new PlayerControls(
            Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.P1_UP]), 
            Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.P1_DOWN]), 
            Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.P1_LEFT]),
            Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.P1_RIGHT]), 
            Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.P1_PUNCH]), 
            Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.P1_KICK]));
        
        Player2Controls = new PlayerControls(
            Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.P2_UP]), 
            Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.P2_DOWN]), 
            Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.P2_LEFT]),
            Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.P2_RIGHT]), 
            Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.P2_PUNCH]), 
            Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.P2_KICK]));

        PauseGame = Converter.StringToKeyCode(Storage.Keys[PlayerPrefsKeys.PAUSE]);

        MusicVolume = Storage.Volumes[PlayerPrefsKeys.MUSIC_VOLUME];
        VFXVolume = Storage.Volumes[PlayerPrefsKeys.VFX_VOLUME];
    }

}
