using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectSource;

    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private AudioClip _levelMusic;

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

    public void PlayMenuMusic()
    {
        if(Instance != null)
        {
            if(_musicSource != null)
            {
                _musicSource.Stop();
                _musicSource.clip = _menuMusic;
                _musicSource.Play();
            }
        }
        else
        {
            Debug.Log("Unavailable SoundManager component");
        }
    }

    public void PlayGameMusic()
    {
        if (Instance != null)
        {
            if (_musicSource != null)
            {
                _musicSource.Stop();
                _musicSource.clip = _levelMusic;
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
}
