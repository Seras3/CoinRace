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

    private static AudioSource _audioSourceMain, _audioSourceSecondary, _audioSourceMusic;

    public float MusicVolume { 
        get => _audioSourceMusic.volume; 
        set => _audioSourceMusic.volume = value; 
    }

    public float VFXVolume
    {
        get => _audioSourceMain.volume;
        set
        {
            _audioSourceMain.volume = value;
            _audioSourceSecondary.volume = value;
        }
    }

    [SerializeField]
    private AudioClip bodyHitImpactSound, wooshSound, deathSound, groundHitSound, bodyHitSound, yesSound, 
        gameMusic, menuMusic, loudCrowdSound, coinCollectSound, hoverMenuSound, selectMenuSound, startRoundSound;
    
    void Awake()
    {
        _instance = this;
        var audioSources = GetComponents<AudioSource>();
        
        if (!_audioSourceMain)
        {
            _audioSourceMain = audioSources[0];
            _audioSourceSecondary = audioSources[1];
            _audioSourceMusic = audioSources[2];
        }
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

    public void YesSoundPlay(AudioSource otherAudioSource)
    {
        var audioSource = otherAudioSource ? otherAudioSource : _audioSourceSecondary;
        audioSource.volume = SettingsManagerScript.Instance.VFXVolume;
        audioSource.clip = yesSound;
        audioSource.Play();
    }
    
    public void CoinCollectSoundPlay(AudioSource otherAudioSource = null)
    {
        var audioSource = otherAudioSource ? otherAudioSource : _audioSourceSecondary;
        audioSource.volume = SettingsManagerScript.Instance.VFXVolume;
        audioSource.clip = coinCollectSound;
        audioSource.Play();
    }
    
    public void GameMusicPlay()
    {
        var audioSource = _audioSourceMusic;
        audioSource.volume = SettingsManagerScript.Instance.MusicVolume;
        audioSource.clip = gameMusic;
        audioSource.Play();
    }

    public void GameMusicPause()
    {
        var audioSource = _audioSourceMusic;
        audioSource.Pause();
    }
    
    public void MenuMusicPlay()
    {
        var audioSource = _audioSourceMusic;
        audioSource.volume = SettingsManagerScript.Instance.MusicVolume;
        audioSource.clip = menuMusic;
        audioSource.Play();
    }

    public void LoudCrowdSoundPlay(AudioSource otherAudioSource = null)
    {
        var audioSource = otherAudioSource ? otherAudioSource : _audioSourceMain;
        audioSource.volume = SettingsManagerScript.Instance.VFXVolume;
        audioSource.clip = loudCrowdSound;
        audioSource.Play();
    }
    
    public void HoverMenuSoundPlayOnEvent()
    {
        var audioSource = _audioSourceMain;
        audioSource.volume = SettingsManagerScript.Instance.VFXVolume;
        audioSource.clip = hoverMenuSound;
        audioSource.Play();
    }
    
    public void SelectMenuSoundPlayOnEvent()
    {
        var audioSource = _audioSourceMain;
        audioSource.volume = SettingsManagerScript.Instance.VFXVolume;
        audioSource.clip = selectMenuSound;
        audioSource.Play();
    }
    
    public void StartRoundSoundPlay(AudioSource otherAudioSource = null)
    {
        var audioSource = otherAudioSource ? otherAudioSource : _audioSourceMain;
        audioSource.volume = SettingsManagerScript.Instance.VFXVolume;
        audioSource.clip = startRoundSound;
        audioSource.Play();
    }
}
