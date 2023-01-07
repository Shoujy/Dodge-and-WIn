using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Art")]
    [SerializeField] private GameObject _enemyPrefab;

    [Header("Settings")]
    [SerializeField] private Vector3 _center;
    [SerializeField] private float _radius;
    [SerializeField] private float _timeDelay;
    [SerializeField] private float _spawnRate;

    private GameFlow _gameFlow;

    private void Awake()
    {
        _gameFlow = FindObjectOfType<GameFlow>();
    }
    private void Start()
    {
        InvokeRepeating("EnemySpawnInRandomCircle", _timeDelay, _spawnRate);
    }

    private void Update()
    {
        if(_gameFlow.IsGameOver == true) { CancelInvoke(); }
    }

    private void EnemySpawnInRandomCircle()
    {
        float angle = Random.value * 360;
        Vector3 position;
        position.x = _center.x + _radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        position.y = _center.y + _radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        position.z = _center.z;

        Instantiate(_enemyPrefab, position, Quaternion.identity);
    }
}
