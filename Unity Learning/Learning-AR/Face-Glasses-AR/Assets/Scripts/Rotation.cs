using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _position;

    private void Update()
    {
        float rotationAmount = _speed * Time.deltaTime;
        transform.Rotate(_position.x * rotationAmount, _position.y * rotationAmount, _position.z * rotationAmount);
    }
}

