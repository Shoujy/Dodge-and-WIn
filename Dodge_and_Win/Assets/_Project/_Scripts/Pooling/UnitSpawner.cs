using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPooler _objectPooler;
    [SerializeField] private GameFlow _gameFlow;

    [Header("Settings")]
    [SerializeField] private Vector3 _center;
    [SerializeField] private float _radius;
    [SerializeField] private float _timeDelay;
    [SerializeField] private float _spawnRate;

    private void Awake()
    {
        _gameFlow = FindObjectOfType<GameFlow>();
    }

    private void Start()
    {
        InvokeRepeating("SpawnUnit", _timeDelay, _spawnRate);
    }

    private void Update()
    {
        if (_gameFlow.IsGameOver == true) { CancelInvoke(); }
    }

    private void SpawnUnit()
    {
        float angle = Random.value * 360;
        Vector3 position;
        position.x = _center.x + _radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        position.y = _center.y + _radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        position.z = _center.z;

        _objectPooler.Spawn(position, Quaternion.identity);
    }

    public void UpgradeDifficult()
    {
        CancelInvoke();
        _spawnRate -= 0.1f;
        InvokeRepeating("SpawnUnit", _timeDelay, _spawnRate);
    }
}
