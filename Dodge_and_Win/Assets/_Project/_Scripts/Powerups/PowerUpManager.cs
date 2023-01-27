using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private List<PowerUp> _powerUps;

    [SerializeField] private float _boundX = 5.0f;
    [SerializeField] private float _boundY = 10.0f;

    [SerializeField] private int _timeDelay = 10;
    [SerializeField] private int _minTimeRate = 7;
    [SerializeField] private int _maxTimeRate = 15;

    private GameFlow _gameFlow;

    private void Awake()
    {
        _gameFlow = FindObjectOfType<GameFlow>();
    }

    private void Start()
    {
        StartCoroutine(SpawnLoop(_timeDelay));
    }

    IEnumerator SpawnLoop(int waitTimeInSeconds)
    {
        int counter = waitTimeInSeconds;
        while(counter > 0) {
            yield return new WaitForSeconds(1);
            counter--;
        }

        SpawnPowerUp();
    }

    private void SpawnPowerUp()
    {
        if (_gameFlow.IsGameOver == true)
        {
            StopAllCoroutines();
            return;
        }

        float randomX = Random.Range(-_boundX, _boundX);
        float randomY = Random.Range(-_boundY, _boundY);

        int randomPowerUp = Random.Range(0, _powerUps.Count);
        Instantiate(_powerUps[randomPowerUp], new Vector2(randomX, randomY), Quaternion.identity);

        int randomDelay = Random.Range(_minTimeRate, _maxTimeRate);
        StartCoroutine(SpawnLoop(randomDelay));
    }
}
