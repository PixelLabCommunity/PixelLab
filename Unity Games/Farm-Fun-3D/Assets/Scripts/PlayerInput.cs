using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _horizontalInput;

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * _horizontalInput * _speed);
    }
}