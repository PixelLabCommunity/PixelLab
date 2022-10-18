using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 15.0f;

    private PlayerControls _playerControlsScript;
    private float _leftBound = -20.0f;

    private void Start()
    {
        _playerControlsScript = GameObject.Find("Player").
            GetComponent<PlayerControls>();
    }

    private void Update()
    {
        if (_playerControlsScript._gameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * _movingSpeed);
        if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}