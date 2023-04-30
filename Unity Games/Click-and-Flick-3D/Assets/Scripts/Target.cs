using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int _pointValue;
    [SerializeField] private int _failedValue;
    [SerializeField] private ParticleSystem _explosionParticle;

    private Rigidbody _targetRb;
    private GameManager _gameManager;
    private AudioSource _clickSoundSource;

    private float _minForce = 12.0f;
    private float _maxForce = 16.0f;
    private float _valueTorque = 10.0f;
    private float _spawnX = 4.0f;
    private float _spawnY = -2.0f;

    private void Start()
    {
        _targetRb = GetComponent<Rigidbody>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _clickSoundSource = GameObject.Find("Game Objects").GetComponent<AudioSource>();

        RandomForce();
        RandomTorque();

        SpawnPosition();
    }

    private void OnMouseDown()
    {
        if (_gameManager._isGameStart)
        {
            _clickSoundSource.Play();
            Destroy(gameObject);
            Instantiate(_explosionParticle, transform.position, transform.rotation);
            _gameManager.UpdateScore(_pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SensorDestroy"))
        {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Bad") && _gameManager._isGameStart)
            {
                _gameManager.UpdateFailed(_failedValue);
            }
        }
    }

    private void RandomForce()
    {
        float _randForceUp = Random.Range(_minForce, _maxForce);
        _targetRb.AddForce(Vector3.up * _randForceUp, ForceMode.Impulse);
    }

    private void RandomTorque()
    {
        float _randTorque = Random.Range(-_valueTorque, _valueTorque);
        _targetRb.AddTorque(_randTorque, _randTorque, _randTorque);
    }

    private void SpawnPosition()
    {
        float _randSpawnX = Random.Range(-_spawnX, _spawnX);
        _targetRb.position = new Vector3(_randSpawnX, _spawnY);
    }
}