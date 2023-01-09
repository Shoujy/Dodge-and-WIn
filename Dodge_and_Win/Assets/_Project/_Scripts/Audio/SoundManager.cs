using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }

    public void PlayMenuMusic(AudioClip clip)
    {
        if(Instance != null)
        {
            if(_musicSource != null)
            {
                _musicSource.Stop();
                _musicSource.clip = clip;
                _musicSource.Play();
            }
        }
        else
        {
            Debug.Log("Unavailable SoundManager component");
        }
    }

    public void PlayGameMusic(AudioClip clip)
    {
        if (Instance != null)
        {
            if (_musicSource != null)
            {
                _musicSource.Stop();
                _musicSource.clip = clip;
                _musicSource.Play();
            }
        }
        else
        {
            Debug.Log("Unavailable SoundManager component");
        }
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }

    public void ChangeMusicVolume(float value)
    {
        _musicSource.volume = value;
    }

    public void ChangeSoundVolume(float value)
    {
        _effectSource.volume = value;
    }
}
