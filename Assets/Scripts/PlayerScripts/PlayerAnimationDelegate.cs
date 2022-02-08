using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationDelegate : MonoBehaviour
{
    public GameObject leftHandAttackPoint, rightHandAttackPoint, leftToeAttackPoint, rightToeAttackPoint;

    public float getUpTimer = 2f;

    private PlayerAnimation _animationScript;

    private AudioSource _audioSource;

    [SerializeField] 
    private AudioClip wooshSound, bodyHitSound, groundHitSound, deathSound;

    private PlayerMovement _playerMovement;
    private LadderController _ladderController;
    private PlayerAttack _playerAttack;

    private int _currentPlayerLayer;
    
    void Start()
    {
        _animationScript = GetComponent<PlayerAnimation>();
        _audioSource = GetComponent<AudioSource>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<PlayerAttack>();
        _ladderController = GetComponent<LadderController>();
        _currentPlayerLayer = transform.gameObject.layer;
    }
    
    void LeftHandAttackPointOn()
    {
        leftHandAttackPoint.SetActive(true);
    }
    
    void LeftHandAttackPointOff()
    {
        if (leftHandAttackPoint.activeInHierarchy)
        {
            leftHandAttackPoint.SetActive(false);
        }
    }
    
    void RightHandAttackPointOn()
    {
        rightHandAttackPoint.SetActive(true);
    }
    
    void RightHandAttackPointOff()
    {
        if (rightHandAttackPoint.activeInHierarchy)
        {
            rightHandAttackPoint.SetActive(false);
        }
    }
    
    void LeftToeAttackPointOn()
    {
        leftToeAttackPoint.SetActive(true);
    }
    
    void LeftToeAttackPointOff()
    {
        if (leftToeAttackPoint.activeInHierarchy)
        {
            leftToeAttackPoint.SetActive(false);
        }
    }
    
    void RightToeAttackPointOn()
    {
        rightToeAttackPoint.SetActive(true);
    }
    
    void RightToeAttackPointOff()
    {
        if (rightToeAttackPoint.activeInHierarchy)
        {
            rightToeAttackPoint.SetActive(false);
        }
    }

    void TagRightHand()
    {
        rightHandAttackPoint.tag = Tags.RIGHT_HAND_TAG;
    }

    void UntagRightHand()
    {
        rightHandAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void TagRightToe()
    {
        rightToeAttackPoint.tag = Tags.RIGHT_TOE_TAG;
    }

    void UntagRightToe()
    {
        rightToeAttackPoint.tag = Tags.UNTAGGED_TAG;
    }

    void PlayerGetUp()
    {
        StartCoroutine(GetUpAfterTime());
    }

    IEnumerator GetUpAfterTime()
    {
        yield return new WaitForSeconds(getUpTimer);
        _animationScript.GetUp();
    }

    void AttackSoundPlay()
    {
        _audioSource.volume = 0.2f;
        _audioSource.clip = wooshSound;
        _audioSource.Play();
    }
    
    void DeathSoundPlay()
    {
        _audioSource.volume = 1f;
        _audioSource.clip = deathSound;
        _audioSource.Play();
    }
    
    void KnockDownSoundPlay()
    {
        _audioSource.volume = 1f;
        _audioSource.clip = groundHitSound;
        _audioSource.Play();
    }

    void HitBodySoundPlay()
    {
        _audioSource.volume = 1f;
        _audioSource.clip = bodyHitSound;
        _audioSource.Play();
    }

    void DisableMovement()
    {
        _playerMovement.enabled = false;
        _ladderController.enabled = false;
        transform.gameObject.layer = Layers.DEFAULT_LAYER;
        DisableAttack(); 
    }
    
    void EnableMovement()
    {
        _playerMovement.enabled = true;
        _ladderController.enabled = true;
        transform.gameObject.layer = _currentPlayerLayer;
        EnableAttack();
    }
    
    void DisableAttack()
    {
        _playerAttack.enabled = false;
    }

    void EnableAttack()
    {
        _playerAttack.enabled = true;
    }
    
}
