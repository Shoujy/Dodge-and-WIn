using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    private PlayerInput _playerInput;
    private GameFlow _gameFlow;

    [SerializeField] private float _speed;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _gameFlow = FindObjectOfType<GameFlow>();
    }

    private void FixedUpdate()
    {
        if (_gameFlow.IsGameOver == true) { return; }
        
        Vector2 move = _playerInput.MoveComposite;

        transform.Translate(move * Time.deltaTime * _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            _gameFlow.ChangeGameState();
        }
    }
}
