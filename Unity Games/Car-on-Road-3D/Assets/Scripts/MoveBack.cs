using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 20.0f;

    private float _backBound = -86.0f;

    private void Update()
    {
        if (gameObject.CompareTag("Box") || gameObject.CompareTag("Obstacle"))
        {
            transform.Translate(Vector3.back * Time.deltaTime * _movingSpeed);
        }
        else if (gameObject.CompareTag("Obstacle 180"))
            transform.Translate(Vector3.forward * Time.deltaTime * _movingSpeed);

        if (transform.position.z < _backBound && !gameObject.CompareTag("Road"))
        {
            Destroy(gameObject);
        }
    }
}