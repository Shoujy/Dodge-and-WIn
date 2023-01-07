using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, Controls.IPlayerActions
{
    private Controls _controls;

    [SerializeField] private Vector2 _moveComposite;

    public Vector2 MoveComposite => _moveComposite;

    private void OnEnable()
    {
        if(_controls != null)
        {
            return;
        }

        _controls = new Controls();
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveComposite = context.ReadValue<Vector2>();
    }
}
