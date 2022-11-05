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
    private Animator _animator;

    private float _zBound = 12.0f;

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

        PlayerBounds();
    }

    private void FixedUpdate()
    {
        _playerRigidbody.velocity = new Vector3(_moveDirections.x * _speed,
           _moveDirections.y, _moveDirections.z * _speed);
    }

    private void PlayerBounds()
    {
        if (_playerRigidbody.position.z > _zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                _zBound);
        }
        else if (_playerRigidbody.position.z < -_zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                -_zBound);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("You collide with enemy");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ExtraLife"))
        {
            Destroy(other.gameObject);
        }
    }
}