using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation _playerAnimation;
    private PlayerControlsScript _playerControlsScript;
    private Rigidbody _myBody;

    public float walkSpeed;

    private float _rotationSpeed = 15f;

    private Direction _movementDirection;

    void Start()
    {
        _myBody = GetComponent<Rigidbody>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerControlsScript = GetComponent<PlayerControlsScript>();
    }

    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }
    
    void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()
    {
        _myBody.velocity = new Vector3(_playerControlsScript.controls.HorizontalAxis() * (-walkSpeed), _myBody.velocity.y,
            _playerControlsScript.controls.VerticalAxis() * (-walkSpeed));
    }

    void RotatePlayer()
    {
        _movementDirection = new Direction(_playerControlsScript.controls.HorizontalAxis(), _playerControlsScript.controls.VerticalAxis());
        if (!_movementDirection.Equals(new Direction(0, 0)))
        {
            transform.rotation = Quaternion.Euler(0f, Movement.ROTATION_Y[_movementDirection], 0f);
        }
    }

    void AnimatePlayerWalk()
    {
        if (_playerControlsScript.controls.HorizontalAxis() != 0 || _playerControlsScript.controls.VerticalAxis() != 0)
        {
            _playerAnimation.Walk(true);
        }
        else
        {
            _playerAnimation.Walk(false);
        }
    }
}
