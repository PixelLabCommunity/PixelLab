using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private float _gravityValue = 18.0f;

    public bool _gameOver;
    private Rigidbody _playerRb;
    private bool _isOnGround = true;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0.0f, -_gravityValue, 0.0f);
    }

    private void Update()
    {
        if (_gameOver == false)
        {
            PlayerJump();
        }
    }

    private void LateUpdate()
    {
        RestartLevel();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            Debug.Log("Game Over! Press 'ESC' for restart the Game!");
        }
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
        }
    }

    private void RestartLevel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var _scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(_scene.name);
        }
    }
}