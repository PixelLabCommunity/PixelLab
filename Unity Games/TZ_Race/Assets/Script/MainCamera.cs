using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Car _car;
    private float smooth = 5.0f;
    private Vector3 offset = new Vector3(-6, 991, -396);
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _car.transform.position + offset, Time.deltaTime * smooth);
    }
}
