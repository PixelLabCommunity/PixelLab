using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _targetRb;

    private float _minForce = 12.0f;
    private float _maxForce = 16.0f;
    private float _valueTorque = 10.0f;
    private float _spawnX = 4.0f;
    private float _spawnY = -6.0f;

    private void Start()
    {
        _targetRb = GetComponent<Rigidbody>();

        RandomForce();
        RandomTorque();

        SpawnPosition();
    }

    private void RandomForce()
    {
        float _randForceUp = Random.Range(_minForce, _maxForce);
        _targetRb.AddForce(Vector3.up * _randForceUp, ForceMode.Impulse);
    }

    private void RandomTorque()
    {
        float _randTorque = Random.Range(-_valueTorque, _valueTorque);
        _targetRb.AddTorque(_randTorque, _randTorque, _randTorque);
    }

    private void SpawnPosition()
    {
        float _randSpawnX = Random.Range(-_spawnX, _spawnX);
        _targetRb.position = new Vector3(_randSpawnX, _spawnY);
    }
}