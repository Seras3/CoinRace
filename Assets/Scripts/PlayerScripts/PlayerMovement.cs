using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation _playerAnimation;
    private PlayerControlsScript _playerControlsScript;
    private Rigidbody _myBody;
    
    
    private float walkSpeed = 5, runSpeed = 6;

    private bool _hasPressedFirstButton, _shouldResetFirstButton;
    private KeyCode? _lastKeyPressed, _currentKeyPressed;
    private float _timeOfFirstButton;
    private float _timeToCatchRunning = 0.5f;

    public float MovementSpeed => _playerAnimation.IsRunning ? runSpeed : walkSpeed;
    
    void Start()
    {
        _myBody = GetComponent<Rigidbody>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerControlsScript = GetComponent<PlayerControlsScript>();
    }

    void Update()
    {
        AnimatePlayerMovement();
    }
    
    void FixedUpdate()
    {
        ApplyMovement();
    }

    void ApplyMovement()
    {
        _myBody.velocity = new Vector3(_playerControlsScript.controls.HorizontalAxis() * (-MovementSpeed),
                _myBody.velocity.y,
                _playerControlsScript.controls.VerticalAxis() * (-MovementSpeed));
    }

    void AnimatePlayerMovement()
    {
        if (_playerControlsScript.controls.HorizontalAxis() != 0 || _playerControlsScript.controls.VerticalAxis() != 0)
        {
            _playerAnimation.Walk(true);
            CheckRunning();
        }
        else
        {
            _playerAnimation.Walk(false);
            _playerAnimation.Run(false);
        }
    }

    void CheckRunning()
    {
        if (_playerControlsScript.GetMovementKeyPressed() == null)  { return; }
        
        _lastKeyPressed = _currentKeyPressed;
        _currentKeyPressed = _playerControlsScript.GetMovementKeyPressed();
        
        
        if(_currentKeyPressed == _lastKeyPressed) 
        {
            if(Time.time - _timeOfFirstButton < _timeToCatchRunning)
            {
                _playerAnimation.Run(true);
            } 
            else 
            {
                _lastKeyPressed = null;
            }
        }

        _timeOfFirstButton = Time.time;

    }
}
