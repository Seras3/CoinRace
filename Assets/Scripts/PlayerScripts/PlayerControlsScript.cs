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
}
