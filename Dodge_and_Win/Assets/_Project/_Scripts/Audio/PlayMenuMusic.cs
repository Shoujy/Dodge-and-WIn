using UnityEngine;

public class PlayMenuMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        if(SoundManager.Instance.MusicSource.clip != _clip)
        {
            SoundManager.Instance.PlayMenuMusic(_clip);
        }
    }
}
