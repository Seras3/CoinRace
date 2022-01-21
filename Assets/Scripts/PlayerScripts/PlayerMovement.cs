using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody myBody;

    public float walkSpeed;

    private float rotationY = 90f;
    private float rotationSpeed = 15f;

    private Direction movementDirection;
    
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        // palyerAnimation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        RotatePlayer();
    }
    
    void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()
    {
        myBody.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walkSpeed), myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-walkSpeed));
    }

    void RotatePlayer()
    {
        movementDirection = new Direction((int)Input.GetAxisRaw(Axis.HORIZONTAL_AXIS), (int)Input.GetAxisRaw(Axis.VERTICAL_AXIS));
        if (!movementDirection.Equals(new Direction(0, 0)))
        {
            transform.rotation = Quaternion.Euler(0f, Movement.ROTATION_Y[movementDirection], 0f);
        }
    }
}
