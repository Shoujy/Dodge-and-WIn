using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlayGameMusic();
    }
}
