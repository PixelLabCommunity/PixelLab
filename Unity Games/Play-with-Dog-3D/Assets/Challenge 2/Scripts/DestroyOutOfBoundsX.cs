using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float _leftLimit = -40.0f;
    private float _bottomLimit = -5.0f;

    // Update is called once per frame
    private void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < _leftLimit)
        {
            Destroy(gameObject);
        }
        // Destroy balls if y position is less than _bottomLimit
        else if (transform.position.y < _bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}