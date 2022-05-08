using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    private static SoundManagerScript _instance;

    public static SoundManagerScript Instance
    {
        get
        {
            if (_instance is null)
            {
                print("SOUND MANAGER is NULL");
            }

            return _instance;
        }
    }

    private AudioSource _audioSourceMain, _audioSourceSecondary;
    
    [SerializeField]
    private AudioClip bodyHitImpactSound, wooshSound, deathSound, groundHitSound, bodyHitSound;
    
    void Awake()
    {
        _instance = this;
    }
    
    void Start()
    {
        var audioSources = GetComponents<AudioSource>();
        _audioSourceMain = audioSources[0];
        _audioSourceSecondary = audioSources[1];
    }

    public void BodyHitImpactPlay(AudioSource otherAudioSource = null)
    {
        var audioSource = otherAudioSource ? otherAudioSource : _audioSourceMain;
        audioSource.volume = SettingsManagerScript.Instance.VFXVolume;
        audioSource.clip = bodyHitImpactSound;
        audioSource.Play();
    }
    
    public void AttackSoundPlay(AudioSource otherAudioSource)
    {
        var audioSource = otherAudioSource ? otherAudioSource : _audioSourceSecondary;
        audioSource.volume = SettingsManagerScript.Instance.VFXVolume;
        audioSource.clip = wooshSound;
        audioSource.Play();
    }
    
    public void DeathSoundPlay(AudioSource otherAudioSource)
    {
        var audioSource = otherAudioSource ? otherAudioSource : _audioSourceSecondary;
        audioSource.volume = SettingsManagerScript.Instance.VFXVolume;
        audioSource.clip = deathSound;
        audioSource.Play();
    }
    
    public void KnockDownSoundPlay(AudioSource otherAudioSource)
    {
        var audioSource = otherAudioSource ? otherAudioSource : _audioSourceSecondary;
        audioSource.volume = SettingsManagerScript.Instance.VFXVolume;
        audioSource.clip = groundHitSound;
        audioSource.Play();
    }

    public void HitBodySoundPlay(AudioSource otherAudioSource)
    {
        var audioSource = otherAudioSource ? otherAudioSource : _audioSourceSecondary;
        audioSource.volume = SettingsManagerScript.Instance.VFXVolume;
        audioSource.clip = bodyHitSound;
        audioSource.Play();
    }
}
