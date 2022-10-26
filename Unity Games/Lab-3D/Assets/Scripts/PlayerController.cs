using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private InputAction _playerControls;

    private Rigidbody _playerRigidbody;
    private Vector3 _moveDirections = Vector3.zero;

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveDirections = _playerControls.ReadValue<Vector3>();
    }

    private void FixedUpdate()
    {
        _playerRigidbody.velocity = new Vector3(_moveDirections.x * _speed,
           _moveDirections.y, _moveDirections.z * _speed);
    }
}