using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _targetRb;

    private void Start()
    {
        _targetRb = GetComponent<Rigidbody>();

        _targetRb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        _targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));

        _targetRb.position = new Vector3(Random.Range(-4, 4), -6);
    }
}