using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private MapPresets _mapPresets;

    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;

    public SpriteRenderer Background => _background;
    public AudioClip Clip => _clip;
    public GameObject Player => _player;
    public GameObject Enemy => _enemy;


    private void Start()
    {
        _background.sprite = _mapPresets.Background;
        _clip = _mapPresets.Clip;
        _player = _mapPresets.Player;
        _enemy = _mapPresets.Enemy;

        PlayerSpawn();
    }


    private void PlayerSpawn()
    {
        Instantiate(_player, Vector3.zero, Quaternion.identity);
    }
}
