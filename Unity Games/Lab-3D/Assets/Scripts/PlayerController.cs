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

    private float _zBoundMax = 7.5f;
    private float _zBoundMin = -11.5f;

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
        if (_playerRigidbody.position.z > _zBoundMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                _zBoundMax);
        }
        else if (_playerRigidbody.position.z < _zBoundMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,
                _zBoundMin);
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