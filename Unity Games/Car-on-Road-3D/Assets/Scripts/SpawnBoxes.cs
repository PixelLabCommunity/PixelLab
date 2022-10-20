using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes : MonoBehaviour
{
    [SerializeField] private GameObject _spawnBoxPrefab;

    private Vector3 _spawnBoxPosition;
    private float _spawnValueX = 5.0f;
    private float _spawnBoxPositionY = 0.0f;
    private float _spawnBoxPositionZ = 97.0f;
    private float _spawnDelay = 1.0f;
    private float _repeatSpawn = 4.0f;
    private PlayerController _playerControllerScript;

    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerController>();
        InvokeRepeating("SpawnBoxPrefab", _spawnDelay, _repeatSpawn);
    }

    private void SpawnBoxPrefab()
    {
        if (_playerControllerScript._gameOver == false)
        {
            float _spawnBoxRandomX = Random.Range(-_spawnValueX, _spawnValueX);
            _spawnBoxPosition = new Vector3(_spawnBoxRandomX, _spawnBoxPositionY,
                _spawnBoxPositionZ);
            Instantiate(_spawnBoxPrefab, _spawnBoxPosition,
                _spawnBoxPrefab.transform.rotation);
        }
    }
}