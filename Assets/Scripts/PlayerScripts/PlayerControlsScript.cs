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
        if (isPlayer1)
        {
            controls = Settings.player1Controls;
        }
        else
        {
            controls = Settings.player2Controls;
        }
    }
}
