using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private AudioClip _crashEnemy;
    [SerializeField] private AudioClip _getPowerUp;
    [SerializeField] private AudioClip _kickPowerUp;

    private Rigidbody _playerRb;
    private GameObject _focalPoint;
    private AudioSource _playerAudioSource;

    private float _volumeScalePowerUp = 10.0f;
    private float _strenghtPowerUp = 15.0f;
    private bool _hasPowerUp = false;

    private void Awake()
    {
        ClearLog();
    }

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
        _playerAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float _playerForwardImput = Input.GetAxis("Vertical");

        _playerRb.AddForce(_focalPoint.transform.forward * _playerSpeed *
            _playerForwardImput);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _playerAudioSource.PlayOneShot(_crashEnemy);
            Debug.Log("Has collide with: " + collision.gameObject.name);
        }
        if (collision.gameObject.CompareTag("Enemy") && _hasPowerUp)
        {
            _playerAudioSource.PlayOneShot(_kickPowerUp, _volumeScalePowerUp);

            Rigidbody _enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 _enemyPowerUpAway = (collision.gameObject.transform.position
                - transform.position);

            _enemyRb.AddForce(_enemyPowerUpAway * _strenghtPowerUp, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            _hasPowerUp = true;
            Destroy(other.gameObject);
            _playerAudioSource.PlayOneShot(_getPowerUp, _volumeScalePowerUp);
        }
    }

    public void ClearLog()
    {
        var _assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var _type = _assembly.GetType("UnityEditor.LogEntries");
        var _method = _type.GetMethod("Clear");
        _method.Invoke(new object(), null);
    }
}