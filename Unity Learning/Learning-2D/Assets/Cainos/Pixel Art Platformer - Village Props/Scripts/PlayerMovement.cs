using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomControls _input = null;
    private Vector2 _movement = Vector2.zero;
    private Rigidbody2D _rb = null;
    private float _moveSpeed = 10.0f;

    private void Awake()
    {
        _input = new CustomControls();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movement * _moveSpeed;
    }

    private void OnEnable()
    {
        _input.Enable();
        _input.Player.Movement.performed += OnMovementPerfomed;
        _input.Player.Movement.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        _input?.Disable();
        _input.Player.Movement.performed -= OnMovementPerfomed;
        _input.Player.Movement.canceled -= OnMovementCanceled;
    }

    private void OnMovementPerfomed(InputAction.CallbackContext value)
    {
        _movement = value.ReadValue<Vector2>();
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        _movement = Vector2.zero;
    }
}