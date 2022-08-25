using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _direction;

    public void SetDirection(float direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        if (_direction != 0)
        {
            var delta = _direction * _speed * Time.deltaTime;
            var newPositionX = transform.position.x + delta;
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }
    }
}