using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;

    private Rigidbody _playerRb;

    // Start is called before the first frame update
    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        float _playerInputKeys = Input.GetAxis("Vertical");
        _playerRb.AddForce(Vector3.forward * _playerSpeed *
            _playerInputKeys);
    }
}