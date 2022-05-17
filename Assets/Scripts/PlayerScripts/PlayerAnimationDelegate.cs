using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationDelegate : MonoBehaviour
{
    public GameObject leftHandAttackPoint, rightHandAttackPoint, leftToeAttackPoint, rightToeAttackPoint;

    public float getUpTimer = 2f;

    private PlayerAnimation _animationScript;

    private AudioSource _audioSource;

    private PlayerMovement _playerMovement;
    private LadderController _ladderController;
    private PlayerRotation _playerRotation;
    private PlayerAttack _playerAttack;

    private int _currentPlayerLayer;
    
    void Start()
    {
        _animationScript = GetComponent<PlayerAnimation>();
        _audioSource = GetComponent<AudioSource>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<PlayerAttack>();
        _ladderController = GetComponent<LadderController>();
        _playerRotation = GetComponent<PlayerRotation>();
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
        SoundManagerScript.Instance.AttackSoundPlay(_audioSource);
    }
    
    void DeathSoundPlay()
    {
        SoundManagerScript.Instance.DeathSoundPlay(_audioSource);
    }
    
    void KnockDownSoundPlay()
    {
        SoundManagerScript.Instance.KnockDownSoundPlay(_audioSource);
    }

    void HitBodySoundPlay()
    {
        SoundManagerScript.Instance.HitBodySoundPlay(_audioSource);
    }

    void YesSoundPlay()
    {
        SoundManagerScript.Instance.YesSoundPlay(_audioSource);
    }

    public void DisableMovement()
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

    void DisableRotation()
    {
        _playerRotation.enabled = false;
    }

    void EnableRotation()
    {
        _playerRotation.enabled = true;
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
