using UnityEngine;

public class PlayMenuMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    private void Start()
    {
        SoundManager.Instance.PlayMenuMusic(_clip);
    }
}
