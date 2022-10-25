using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 _startPos;
    private float _repeatWidth;

    private void Start()
    {
        // Establish the default starting position
        _startPos = transform.position;
        // Set repeat width to half of the background
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position
        if (transform.position.x < _startPos.x - _repeatWidth)
        {
            transform.position = _startPos;
        }
    }
}