using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _directionX;
    private float _directionY;

    public void SetDirectionX(float directionX)
    {
        _directionX = directionX;
    }

    public void SetDirectionY(float directionY)
    {
        _directionY = directionY;
    }

    private void Update()
    {
        if (_directionX != 0)
        {
            var deltaX = _directionX * _speed * Time.deltaTime;
            var newPositionX = transform.position.x + deltaX;
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }
        else if (_directionY != 0)
        {
            var deltaY = _directionY * _speed * Time.deltaTime;
            var newPositionY = transform.position.y + deltaY;
            transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
        }
    }
}