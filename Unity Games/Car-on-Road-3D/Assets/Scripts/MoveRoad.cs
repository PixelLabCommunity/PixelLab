using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 15.0f;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _movingSpeed);
    }
}