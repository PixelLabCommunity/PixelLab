using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes : MonoBehaviour
{
    [SerializeField] private GameObject _spawnBoxPrefab;

    private Vector3 _spawnBoxPosition;
    private float _spawnBoxRandomX;
    private float _spawnDelay = 1.0f;
    private float _repeatSpawn = 6.0f;

    private void Start()
    {
        _spawnBoxRandomX = Random.Range(-10, 10);
        _spawnBoxPosition = new Vector3(_spawnBoxRandomX, 0, 97);

        InvokeRepeating("SpawnBoxPrefab", _spawnDelay, _repeatSpawn);
    }

    private void SpawnBoxPrefab()
    {
        Instantiate(_spawnBoxPrefab, _spawnBoxPosition,
            _spawnBoxPrefab.transform.rotation);
    }
}