using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRespawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoints;

    private int _lastIndex, _currentIndex;
    
    void Start()
    {
        _lastIndex = 0;
        gameObject.transform.position = _spawnPoints[_lastIndex].transform.position;
    }

    public void Respawn()
    {
        _currentIndex = Random.Range(0, _spawnPoints.Length);
        
        while (_currentIndex == _lastIndex)
        {
            _currentIndex = Random.Range(0, _spawnPoints.Length);
        }

        _lastIndex = _currentIndex;
        gameObject.transform.position = _spawnPoints[_currentIndex].transform.position;
        gameObject.SetActive(true);
    }
}
