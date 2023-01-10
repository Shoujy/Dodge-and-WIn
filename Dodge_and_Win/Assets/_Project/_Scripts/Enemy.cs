using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private Vector3 _directionToPlayer;
    [SerializeField] private float _speed;

    private GameFlow _gameFlow;
    private GameUI _gameUI;
    private SpawnManager _spawnManager;

    private void Awake()
    {
        _player = GameObject.Find("Player");
        _gameFlow = FindObjectOfType<GameFlow>();
        _gameUI = FindObjectOfType<GameUI>();
        _spawnManager = FindObjectOfType<SpawnManager>();
    }

    private void Start()
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

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_gameFlow.IsGameOver == false)
        {
            _gameUI.IncreaseScore();
        }

        _gameUI.ScoreChange();

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}