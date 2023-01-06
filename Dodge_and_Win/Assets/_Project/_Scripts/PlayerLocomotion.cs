using System;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    private PlayerInput _playerInput;

    [SerializeField] private float _speed;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        // if (isGameOver == true) { return; }
        Vector2 move = _playerInput.MoveComposite;

        transform.Translate(move * Time.deltaTime * _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy touch you!");
        }
    }
}
