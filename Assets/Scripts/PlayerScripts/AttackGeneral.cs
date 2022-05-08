using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackGeneral : MonoBehaviour
{

    public LayerMask collisionLayer;
    public float radius = 0.1f;
    public float damage = 10f;

    public GameObject hitFX;
    

    void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hit.Length > 0)
        {
            print("We Hit The " + hit[0].gameObject.name);

            if (hit[0].gameObject.name.Equals(ObjectNames.PLAYER_1) || hit[0].gameObject.name.Equals(ObjectNames.PLAYER_2))
            {
                SoundManagerScript.Instance.BodyHitImpactPlay();
            }

            if (gameObject.CompareTag(Tags.RIGHT_HAND_TAG) || gameObject.CompareTag(Tags.RIGHT_TOE_TAG))
            {
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
            }
            else
            {
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
            }
            
            gameObject.SetActive(false);
        }
    
    }
}
