using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private PlayerControlsScript _playerControlsScript;
    
    private Direction _movementDirection;

    void Start()
    {
        _playerControlsScript = GetComponent<PlayerControlsScript>();
    }

    void Update()
    {
        _movementDirection = new Direction(_playerControlsScript.controls.HorizontalAxis(), _playerControlsScript.controls.VerticalAxis());
        if (!_movementDirection.Equals(new Direction(0, 0)))
        {
            transform.rotation = Quaternion.Euler(0f, Movement.ROTATION_Y[_movementDirection], 0f);
        }
    }

}