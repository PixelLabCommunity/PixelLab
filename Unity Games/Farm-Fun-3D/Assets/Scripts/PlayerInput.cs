using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefabPizza;

    private float _horizontalInput;
    private readonly float _xRange = 16.5f;

    private void Update()
    {
        PlayerBounds();

        // Keep Player move
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(_horizontalInput * _speed * Time.deltaTime * Vector3.right);

        // Keep Player throw pizza
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_prefabPizza, transform.position, _prefabPizza.transform.rotation);
        }
    }

    private void PlayerBounds()
    {
        // Keep Player in bounds
        if (transform.localPosition.x <= -_xRange)
        {
            transform.localPosition = new Vector3(-_xRange, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x >= _xRange)
        {
            transform.localPosition = new Vector3(_xRange, transform.localPosition.y, transform.localPosition.z);
        }
    }
}