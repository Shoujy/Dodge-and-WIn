using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    public void PlayButtonSound()
    {
        SoundManager.Instance.PlaySound(_clip);
    }
}
