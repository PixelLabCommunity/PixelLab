using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 20.0f;

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _movingSpeed);
    }
}