using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    private PlayerControllerX _playerControllerScript;
    private float _leftBound = -10;

    // Start is called before the first frame update
    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerControllerX>();
    }

    private void Update()
    {
        // If game is not over, move to the left
        if (!_playerControllerScript._gameOver)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < _leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }
}