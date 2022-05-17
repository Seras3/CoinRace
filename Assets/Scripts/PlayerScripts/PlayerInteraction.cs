using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool ShouldRespawn { get; set; }

    [SerializeField] private GameObject _respawnPoint, _deathPoint;

    private float _respawnTime = 5;
    
    private bool HasRoundEnded { get; set; }
    
    void Start()
    {
        Respawn();
    }

    private void Update()
    {
        if (!HasRoundEnded && transform.position.y < _deathPoint.transform.position.y)
        {
            GameManagerScript.Instance.EndRound(gameObject.name != ObjectNames.PLAYER_1);
            HasRoundEnded = true;
        }
    }

    private void Respawn()
    {
        transform.position = _respawnPoint.transform.position;
    }
    
    private IEnumerator RespawnWithDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Respawn();
        ShouldRespawn = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!ShouldRespawn && other.gameObject.name.Contains(ObjectNames.BLOCK_AREA))
        {
            ShouldRespawn = true;
            StartCoroutine(RespawnWithDelay(_respawnTime));
        }
    }
}
