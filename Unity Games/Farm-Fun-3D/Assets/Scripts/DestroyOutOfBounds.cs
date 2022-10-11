using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _topBounds = 30.0f;
    private float _lowBounds = -13;

    private void Update()
    {
        if (transform.position.z > _topBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < _lowBounds)
        {
            Destroy(gameObject);
        }
    }
}