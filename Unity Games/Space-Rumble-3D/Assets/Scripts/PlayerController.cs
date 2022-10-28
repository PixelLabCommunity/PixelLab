using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;

    private Rigidbody _playerRb;
    private GameObject _focalPoint;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        float _playerForwardImput = Input.GetAxis("Vertical");

        _playerRb.AddForce(_focalPoint.transform.forward * _playerSpeed *
            _playerForwardImput);
    }
}