using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRotation : MonoBehaviour
{
    [SerializeField] private int _speed = 5;
    [SerializeField] private Vector3 _position = new(4, 5, 2);

    private void Update()
    {
        transform.Rotate(_position*Time.deltaTime * _speed);
    }
}
