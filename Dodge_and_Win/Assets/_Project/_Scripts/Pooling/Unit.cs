using UnityEngine;

public class Unit : MonoBehaviour, IPoolable
{
    [SerializeField] private ObjectPooler _objectPooler;
    [SerializeField] private GameObject _player;
    private GameFlow _gameFlow;
    private GameUI _gameUI;

    [SerializeField] private Vector3 _directionToPlayer;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _objectPooler = FindObjectOfType<ObjectPooler>();
        _player = GameObject.Find("Player");
        _gameFlow = FindObjectOfType<GameFlow>();
        _gameUI = FindObjectOfType<GameUI>();
        
    }

    public void OnSpawn()
    {
        _directionToPlayer = (_player.transform.position - transform.position).normalized;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_directionToPlayer * _speed * Time.deltaTime);
    }

    public void OnDespawn()
    {
        if (_gameFlow.IsGameOver == false)
        {
            _gameUI.IncreaseScore();
        }

        _gameUI.ScoreChange();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _objectPooler.Despawn(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _objectPooler.Despawn(gameObject);
        }
    }
}
