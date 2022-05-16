using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool ShouldRespawn { get; set; }

    [SerializeField] private GameObject _respawnPoint, _deathPoint;

    void Start()
    {
        transform.position = _respawnPoint.transform.position;
    }

    private void Update()
    {
        if (transform.position.y < _deathPoint.transform.position.y)
        {
            GameManagerScript.Instance.EndGame(gameObject.name != ObjectNames.PLAYER_1);
        }
    }
}
