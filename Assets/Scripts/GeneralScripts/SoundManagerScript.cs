using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    private AudioSource _audioSource;
    
    [SerializeField]
    private AudioClip bodyHitImpactSound;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void BodyHitImpactPlay()
    {
        _audioSource.volume = 0.2f;
        _audioSource.clip = bodyHitImpactSound;
        _audioSource.Play();
    }
}
