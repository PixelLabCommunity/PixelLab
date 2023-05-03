using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTemplate_RotateCube : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1.0f;
    [SerializeField] private Vector3 _cubeRotation;

    private void Update()
    {
        transform.Rotate(_cubeRotation * Time.deltaTime * _rotateSpeed); 
    }
}
