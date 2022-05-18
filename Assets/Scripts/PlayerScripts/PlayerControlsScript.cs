using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsScript : MonoBehaviour
{
    public bool isPlayer1;
    [SerializeField]
    public PlayerControls controls;
    
    void Start()
    {
        controls = isPlayer1 ? SettingsManagerScript.Instance.Player1Controls : SettingsManagerScript.Instance.Player2Controls;
    }

    public KeyCode? GetMovementKeyPressed()
    {
        if (Input.GetKeyDown(controls.moveUp))
        {
            return controls.moveUp;
        }
        
        if (Input.GetKeyDown(controls.moveDown))
        {
            return controls.moveDown;
        }
        
        if (Input.GetKeyDown(controls.moveLeft))
        {
            return controls.moveLeft;
        }
        
        if (Input.GetKeyDown(controls.moveRight))
        {
            return controls.moveRight;
        }

        return null;
    }
}
