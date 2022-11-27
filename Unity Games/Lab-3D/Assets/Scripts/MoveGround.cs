using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField] private float _movingSpeed = 20.0f;
    private PlayerController _playerControllerScript;

    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_playerControllerScript._gameOver == false)
            transform.Translate(Vector3.back * Time.deltaTime * _movingSpeed);
    }
}