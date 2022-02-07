using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float health = 100f;

    private PlayerAnimation _animationScript;
    private PlayerMovement _movementScript;

    private bool isDead;
    private UIManagerScript _uiManagerScript;
    private bool isPlayer1;

    void Start()
    {
        _animationScript = GetComponent<PlayerAnimation>();
        _uiManagerScript = GameObject.Find(ObjectNames.UI_MANAGER).GetComponent<UIManagerScript>();
        isPlayer1 = transform.gameObject.name.Equals(ObjectNames.PLAYER_1);
    }

    public void ApplyDamage(float damage, bool shouldKnockDown)
    {
        if (isDead)
        {
            return;
        }

        health -= damage;
        _uiManagerScript.DisplayHealthUI(isPlayer1, health);


        if (health <= 0f)
        {
            isDead = true;
            _animationScript.Death();

            // TODO: deactivate scripts
            return;
        }
        
        if (shouldKnockDown)
        {
            if (Random.Range(0, 2) > 0)
            {
                _animationScript.KnockDown();
            }
        }
        else
        {
            _animationScript.Hit();
        }
    }
}
