using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private InputAction _playerControls;

        private Rigidbody _rigidbody;
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
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _moveDirections = _playerControls.ReadValue<Vector3>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector3(_moveDirections.x * _speed, 0.0f, _moveDirections.z * _speed);
        }
    }
}