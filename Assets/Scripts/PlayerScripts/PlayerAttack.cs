using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH1,
    PUNCH2,
    PUNCH3,
    KICK1,
    KICK2
}

public class PlayerAttack : MonoBehaviour
{
    private Animator _animator;
    private PlayerAnimation _playerAnimation;
    private PlayerControlsScript _playerControlsScript;

    private bool activateTimerToReset;

    private float currentComboTimer;
    
    // time for action next attack to chain a combo
    private Dictionary<ComboState, float> _comboTimers = new Dictionary<ComboState, float>
    {
        {ComboState.NONE, 0.4f},
        {ComboState.PUNCH1, 0.3f},
        {ComboState.PUNCH2, 0.2f},
        {ComboState.PUNCH3, 0.4f},
        {ComboState.KICK1, 0.4f},
        {ComboState.KICK2, 0.4f},
    };
    
    private ComboState currentComboState;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerControlsScript = GetComponent<PlayerControlsScript>();
        
        currentComboTimer = _comboTimers[ComboState.NONE];
        currentComboState = ComboState.NONE;
    }

    void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    // Combos:
    // --- Punches ---
    // P1
    // P1 P2
    // P1 P2 P3
    // --- Kicks ---
    // K1
    // K1 K2
    // --- Combined --
    // P1 K1
    // P1 K1 K2
    // P1 P2 K1
    // P1 P2 K1 K2
    void ComboAttacks()
    {
        // This wait for animations to finish, preventing from getting input
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(AnimationNames.KICK_2) ||
            _animator.GetCurrentAnimatorStateInfo(0).IsName(AnimationNames.PUNCH_3))
        {
            return;
        }
        
        if (Input.GetKeyDown(_playerControlsScript.controls.punch))
        {
            if (currentComboState >= ComboState.PUNCH3)
            {
                return;
            }
            
            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = _comboTimers[currentComboState];

            if (currentComboState == ComboState.PUNCH1)
            {
                _playerAnimation.Punch1();
            }
            
            if (currentComboState == ComboState.PUNCH2)
            {
                _playerAnimation.Punch2();
            }
            
            if (currentComboState == ComboState.PUNCH3)
            {
                _playerAnimation.Punch3();
            }
        }
        
        if (Input.GetKeyDown(_playerControlsScript.controls.kick))
        {
            if (currentComboState == ComboState.PUNCH3 || currentComboState == ComboState.KICK2)
            {
                return;
            }

            if (currentComboState == ComboState.NONE || currentComboState == ComboState.PUNCH1 || 
                currentComboState == ComboState.PUNCH2)
            {
                currentComboState = ComboState.KICK1;
            } 
            else if (currentComboState == ComboState.KICK1)
            {
                currentComboState++;
            }
            
            activateTimerToReset = true;
            currentComboTimer = _comboTimers[currentComboState];
            
            if (currentComboState == ComboState.KICK1)
            {
                _playerAnimation.Kick1();
            }
            
            if (currentComboState == ComboState.KICK2)
            {
                _playerAnimation.Kick2();
            }
        }
    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            currentComboTimer -= Time.deltaTime;

            if (currentComboTimer <= 0f)
            {
                currentComboState = ComboState.NONE;
                activateTimerToReset = false;
                currentComboTimer = _comboTimers[currentComboState];
            }
        }
    }
}
