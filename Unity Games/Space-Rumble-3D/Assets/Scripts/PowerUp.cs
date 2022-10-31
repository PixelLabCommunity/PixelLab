using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private float _speed = 5.0f;
    private Vector3 _rotateY = new Vector3(0.0f, 30.0f, 0.0f);

    private void Update()
    {
        RotatePowerUp();
    }

    private void RotatePowerUp()
    {
        transform.Rotate(_rotateY * Time.deltaTime * _speed);
    }
}