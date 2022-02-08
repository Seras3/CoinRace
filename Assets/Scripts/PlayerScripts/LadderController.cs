using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    public float speedUpDown = 3.2f;
    private PlayerControlsScript _playerControlsScript;
    private PlayerMovement _playerMovement;
    private Rigidbody _playerBody;
    public bool isClimbing;

    void Start()
    {
        _playerControlsScript = GetComponent<PlayerControlsScript>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerBody = GetComponent<Rigidbody>();
        isClimbing = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        print("ENTER: " + collider.gameObject.tag);
        if (collider.gameObject.CompareTag(Tags.LADDER_TAG))
        {
            GetComponent<PlayerMovement>().enabled = false;
            isClimbing = true;
        }
    }

    bool isDead()
    {
        return GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(AnimationTags.DEATH_TRIGGER);
    }
    
    void OnTriggerExit(Collider collider)
    {
        print("EXIT: " + collider.gameObject.tag);
        if (collider.gameObject.CompareTag(Tags.LADDER_TAG))
        {
            if (!isDead()) // solve weird bug when die on ladders
            {
                GetComponent<PlayerMovement>().enabled = true;
            }
            isClimbing = false;
        }
    }
 
    
    void FixedUpdate()
    {
        DetectMovement();
    }

    void DetectMovement()
    {
        if (isClimbing)
        {
            _playerBody.velocity = new Vector3(
                _playerControlsScript.controls.HorizontalAxis() * (-_playerMovement.walkSpeed), 
                _playerControlsScript.controls.VerticalAxis() * (speedUpDown),
                _playerBody.velocity.z);
        }
    }
    
}
