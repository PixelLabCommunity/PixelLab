using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private AudioClip _crashEnemy;
    [SerializeField] private AudioClip _getPowerUp;
    [SerializeField] private AudioClip _kickPowerUp;
    [SerializeField] private GameObject _indicatorPowerUp;
    [SerializeField] private GameObject _indicatorPowerUpExtra;
    [SerializeField] private InputAction _playerControls;

    private Rigidbody _playerRb;
    private GameObject _focalPoint;
    private AudioSource _playerAudioSource;
    private Vector3 _indicatorPosPowerUp = new Vector3(0.0f, -0.35f, 0.0f);

    private float _volumeScalePowerUp = 10.0f;
    private float _strenghtPowerUp = 15.0f;
    private bool _hasPowerUp = false;
    private bool _hasPowerUpExtra = false;
    private float _timePowerUp = 5.0f;

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
        _playerAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _playerAudioSource.PlayOneShot(_crashEnemy);
        }
        if (collision.gameObject.CompareTag("Enemy") && _hasPowerUp)
        {
            _playerAudioSource.PlayOneShot(_kickPowerUp, _volumeScalePowerUp);

            Rigidbody _enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 _enemyPowerUpAway = (collision.gameObject.transform.position
                - transform.position);

            _enemyRb.AddForce(_enemyPowerUpAway * _strenghtPowerUp, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Enemy") && _hasPowerUpExtra)
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            _hasPowerUp = true;
            Destroy(other.gameObject);
            _playerAudioSource.PlayOneShot(_getPowerUp, _volumeScalePowerUp);
            _indicatorPowerUp.SetActive(true);
            StartCoroutine(PowerUpTimer());
        }
        if (other.CompareTag("PowerUpExtra"))
        {
            _hasPowerUpExtra = true;
            Destroy(other.gameObject);

            _playerAudioSource.PlayOneShot(_getPowerUp, _volumeScalePowerUp);
            _indicatorPowerUpExtra.SetActive(true);
            StartCoroutine(PowerUpTimer());
        }
    }

    private IEnumerator PowerUpTimer()
    {
        yield return new WaitForSeconds(_timePowerUp);
        _hasPowerUp = false;
        _hasPowerUpExtra = false;
        _indicatorPowerUp.SetActive(false);
        _indicatorPowerUpExtra.SetActive(false);
    }

    private void PlayerMovement()
    {
        Vector2 playerInput = _playerControls.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(playerInput.x, 0f, playerInput.y);

        _playerRb.AddForce(moveDirection * _playerSpeed);

        _indicatorPowerUp.transform.position = transform.position + _indicatorPosPowerUp;
        _indicatorPowerUpExtra.transform.position = transform.position + _indicatorPosPowerUp;
    }
}