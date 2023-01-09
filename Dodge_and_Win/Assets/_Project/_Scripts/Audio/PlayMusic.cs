using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        SoundManager.Instance.PlayGameMusic(_clip);
    }
}
