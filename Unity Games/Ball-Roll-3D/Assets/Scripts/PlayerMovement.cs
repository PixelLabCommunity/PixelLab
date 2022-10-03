using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private InputAction _playerControls;
        [SerializeField] private TextMeshProUGUI _countText, _winText;

        private Rigidbody _rigidbody;
        private Vector3 _moveDirections = Vector3.zero;
        private int _count;

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
            _count = 0;
            SetCount();
            _winText.text = "";
        }

        private void Update()
        {
            _moveDirections = _playerControls.ReadValue<Vector3>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector3(_moveDirections.x * _speed, -5f, _moveDirections.z * _speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Cube"))
            {
                Destroy(other.gameObject);
                _count++;
                SetCount();
            }
        }

        private void SetCount()
        {
            _countText.text = "Points: " + _count.ToString();
            if (_count == 9)
            {
                _winText.text = "Grats !!! You WON !!!";
            }
        }
    }
}