using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10.0f;

    private Rigidbody _playerRb;
    private float _horizontalInput;
    public bool _gameOver;

    private void Start()
    {
        _gameOver = false;
        _playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        PlayerControls();
    }

    private void PlayerControls()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (_gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed *
            _horizontalInput);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}