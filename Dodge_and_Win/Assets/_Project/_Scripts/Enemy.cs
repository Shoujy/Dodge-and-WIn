using System;
using System.Xml.Serialization;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private Vector3 _directionToPlayer;
    [SerializeField] private float _speed;

    private GameFlow _gameFlow;
    private GameUI _gameUI;

    private void Awake()
    {
        _player = GameObject.Find("Player");
        _gameFlow = FindObjectOfType<GameFlow>();
        _gameUI = FindObjectOfType<GameUI>();
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

        Destroy(this.gameObject);
    }
}