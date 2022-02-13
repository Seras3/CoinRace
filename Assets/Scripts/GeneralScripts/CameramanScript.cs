using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameramanScript : MonoBehaviour
{
    public Transform player1, player2;

    public Vector3 offset;

    public Vector3 desiredPosition;
    
    private Vector2 xyPlayer1, xyPlayer2;
    private float collideOffset;

    void Start()
    {
        desiredPosition = new Vector3();
        xyPlayer1 = new Vector2();
        xyPlayer2 = new Vector2();
    }
    
    void Update()
    {
        xyPlayer1.x = player1.position.x;
        xyPlayer1.y = player1.position.y;
        
        xyPlayer2.x = player2.position.x;
        xyPlayer2.y = player2.position.y;

        collideOffset = Vector2.Distance(xyPlayer1, xyPlayer2);
        
        desiredPosition.x = offset.x + (player1.position.x + player2.position.x) / 2;
        desiredPosition.y = offset.y + Mathf.Max(player1.position.y, player2.position.y) + collideOffset;
        desiredPosition.z = offset.z + Mathf.Max(player1.position.z, player2.position.z) + collideOffset;
        transform.position = desiredPosition;
    }
}
