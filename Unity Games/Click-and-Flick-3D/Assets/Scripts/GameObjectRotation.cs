using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectRotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 10.0f;
    [SerializeField] private Vector2 _rotaionPositions;

    private void Update()
    {
        transform.Rotate(_rotaionPositions * Time.deltaTime * _rotationSpeed);
    }
}