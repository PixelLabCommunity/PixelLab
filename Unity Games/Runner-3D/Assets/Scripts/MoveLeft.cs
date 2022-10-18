using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 15.0f;
    private PlayerControls _playerControlsScript;

    private void Start()
    {
        _playerControlsScript = GameObject.Find("Player").
            GetComponent<PlayerControls>();
    }

    private void Update()
    {
        if (_playerControlsScript._gameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * _movingSpeed);
    }
}