using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleChange;
    [SerializeField] private Vector3 _positionChange;
    [SerializeField] private Vector3 _rotationChange;

    private void Update()
    {
        transform.localScale += _scaleChange;
        transform.localPosition += _positionChange;
        transform.Rotate(_rotationChange);
    }
}
