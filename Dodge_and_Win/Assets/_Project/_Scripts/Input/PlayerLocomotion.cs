using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private GameFlow _gameFlow;
    private Rigidbody2D _playerRB;
    

    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    [SerializeField] private float _speed;

    public float Speed => _speed;

    private void Awake()
    {
        _joystick = FindObjectOfType<FloatingJoystick>();
        _gameFlow = FindObjectOfType<GameFlow>();
        _playerRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_gameFlow.IsGameOver == true) { return; }

        _smoothedMovementInput = Vector2.SmoothDamp(
            _smoothedMovementInput,
            _joystick.Direction.normalized,
            ref _movementInputSmoothVelocity,
            0.05f);

        _playerRB.velocity = _smoothedMovementInput * _speed;

        //Vector2 move = _joystick.Direction.normalized;

        //transform.Translate(move * Time.deltaTime * _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            _playerRB.velocity = Vector2.zero;

            _gameFlow.ChangeGameState();

            var enemies = FindObjectsOfType<Unit>();
            var objectPooler = FindObjectOfType<ObjectPooler>();

            for (int i = 0; i < enemies.Length; i++)
            {
                objectPooler.Despawn(enemies[i].gameObject);
            }
        }
    }

    public void SpeedUp(float speedMultiplier)
    {
        _speed *= speedMultiplier;
    }

    public void ReturnBasicSpeed(float basicSpeed)
    {
        _speed = basicSpeed;
    }
}
