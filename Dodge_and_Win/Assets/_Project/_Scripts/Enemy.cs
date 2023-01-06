using System;
using System.Xml.Serialization;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private Vector3 _directionToPlayer;
    [SerializeField] private float _speed;

    private void Awake()
    {
        _player = GameObject.Find("Player");
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
        Destroy(this.gameObject);
    }
}