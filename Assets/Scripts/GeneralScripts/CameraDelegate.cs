using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraDelegate : MonoBehaviour
{
    public Transform player1, player2;

    public Camera mainCamera, player1Camera, player2Camera, mapCamera;

    public float collideOffset;
    
    private Vector2 xyPlayer1, xyPlayer2;


    private void Start()
    {
        // Disable all here for solving stacking cameras problem
        mainCamera.enabled = false;
        
        player1Camera.enabled = false;
        player2Camera.enabled = false;
        mapCamera.enabled = false;
    }
    
    private void FixedUpdate()
    {
        xyPlayer1 = new Vector2(player1.position.x, player1.position.y);
        xyPlayer2 = new Vector2(player2.position.x, player2.position.y);
        
        if (Vector2.Distance(xyPlayer1, xyPlayer2) > collideOffset)
        {
            mainCamera.enabled = false;
            
            player1Camera.enabled = true;
            player2Camera.enabled = true;
            mapCamera.enabled = true;
        }
        else
        {
            player1Camera.enabled = false;
            player2Camera.enabled = false;
            mapCamera.enabled = false;

            mainCamera.enabled = true;
        }
    }
    
}
