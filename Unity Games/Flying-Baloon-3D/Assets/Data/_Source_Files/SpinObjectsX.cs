using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObjectsX : MonoBehaviour
{
    [SerializeField] private float _spinSpeed = 50.0f;

    private void Update()
    {
        transform.Rotate(Vector3.up, _spinSpeed * Time.deltaTime);
    }
}