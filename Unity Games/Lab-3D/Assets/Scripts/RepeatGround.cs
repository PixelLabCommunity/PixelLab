using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    private Vector3 _startPos;
    private float _repeatWide;

    private void Start()
    {
        _startPos = transform.position;
        _repeatWide = GetComponent<BoxCollider>().size.z / 2.0f;
    }

    private void Update()
    {
        if (transform.position.z < _startPos.z - _repeatWide)
        {
            transform.position = _startPos;
        }
    }
}