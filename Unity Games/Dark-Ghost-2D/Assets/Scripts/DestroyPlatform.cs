using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    private float _leftBounds = -22.0f;

    private void Update()
    {
        if (transform.position.x < _leftBounds)
        {
            Destroy(gameObject);
        }
    }
}