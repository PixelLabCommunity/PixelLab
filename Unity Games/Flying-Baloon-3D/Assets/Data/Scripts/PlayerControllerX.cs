using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField] private float _floatForce = 10.0f;
    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private ParticleSystem _fireworksParticle;

    private Rigidbody _playerRb;
    private AudioSource _playerAudio;
    public AudioClip _moneySound;
    public AudioClip _explodeSound;

    public bool _gameOver;
    private float _gravityModifier = 1.5f;
    private float _upBound = 15.35f;
    private float _downBound = 1.2f;

    private void Start()
    {
        Physics.gravity *= _gravityModifier;
        _playerAudio = GetComponent<AudioSource>();
        _playerRb = GetComponent<Rigidbody>();
        // Apply a small upward force at the start of the game
        _playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    private void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !_gameOver)
        {
            _playerRb.AddForce(Vector3.up * _floatForce, ForceMode.Impulse);
        }
        if (transform.position.y >= _upBound)
        {
            _playerRb.AddForce(Vector3.down * 5, ForceMode.Impulse);

            transform.position = new Vector3(transform.position.x, _upBound,
                transform.position.z);
        }
        else if (transform.position.y <= _downBound)
        {
            _playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

            transform.position = new Vector3(transform.position.x, _downBound,
                transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set _gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            _explosionParticle.Play();
            _playerAudio.PlayOneShot(_explodeSound, 1.0f);
            _gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            _fireworksParticle.Play();
            _playerAudio.PlayOneShot(_moneySound, 1.0f);
            Destroy(other.gameObject);
        }
    }
}