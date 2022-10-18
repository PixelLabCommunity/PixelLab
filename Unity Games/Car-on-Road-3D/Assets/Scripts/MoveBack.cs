using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 15.0f;

    private float _backBound = -86.0f;

    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _movingSpeed);
        if (transform.position.z < _backBound && gameObject.CompareTag("Box"))
        {
            Destroy(gameObject);
        }
    }
}