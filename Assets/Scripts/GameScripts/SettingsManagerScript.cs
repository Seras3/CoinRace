using System;
using System.Collections;
using System.Collections.Generic;
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
    }
    
    public void VFXVolumeControl(Single volume)
    {
        VFXVolume = volume;
    }
    
    private void Awake()
    {
        _instance = this;
        
        Player1Controls = new PlayerControls(
            KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, 
            KeyCode.F, KeyCode.G);
        
        Player2Controls = new PlayerControls(
            KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow, 
            KeyCode.Keypad1, KeyCode.Keypad2);

        PauseGame = KeyCode.Escape;

        MusicVolume = 1;
        VFXVolume = 1;
    }
    
}
