using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField] private GameObject _powerupIndicator;
    [SerializeField] private ParticleSystem _extraSpeedParticle;
    [SerializeField] private int _powerUpDuration = 5;
    [SerializeField] private bool _hasPowerup;

    private Rigidbody _playerRb;
    private GameObject _focalPoint;

    private float _speed = 500.0f;
    private float _extraSpeed = 1000.0f;
    private float _normalStrength = 10.0f; // how hard to hit enemy without powerup
    private float _powerupStrength = 25.0f; // how hard to hit enemy with powerup
    private Vector3 _powerUpTransformPos = new Vector3(0, -0.6f, 0);

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        // Add force to _player in direction of the focal point (and camera)
        float verticalInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(_focalPoint.transform.forward * verticalInput * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            _playerRb.AddForce(_focalPoint.transform.forward * _extraSpeed * Time.deltaTime);
            _extraSpeedParticle.Play();
        }

        // Set powerup indicator position to beneath _player
        _powerupIndicator.transform.position = transform.position + _powerUpTransformPos;
    }

    // If Player collides with powerup, activate powerup
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            _hasPowerup = true;
            _powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
        }
    }

    // Coroutine to count down powerup duration
    private IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(_powerUpDuration);
        _hasPowerup = false;
        _powerupIndicator.SetActive(false);
    }

    // If Player collides with enemy
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position
                - transform.position).normalized;

            if (_hasPowerup) // if have powerup hit enemy with powerup force
            {
                enemyRigidbody.AddForce(awayFromPlayer * _powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength
            {
                enemyRigidbody.AddForce(awayFromPlayer * _normalStrength, ForceMode.Impulse);
            }
        }
    }
}