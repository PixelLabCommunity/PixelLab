using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private float _speed = 200.0f;

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * _speed * Time.deltaTime);

        transform.position = _player.transform.position;
    }
}