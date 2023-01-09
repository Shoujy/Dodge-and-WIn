using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;

    private void Start()
    {
        SoundManager.Instance.ChangeMusicVolume(_musicSlider.value);
        SoundManager.Instance.ChangeSoundVolume(_soundSlider.value);

        _musicSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));
        _soundSlider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeSoundVolume(val));
    }
}
