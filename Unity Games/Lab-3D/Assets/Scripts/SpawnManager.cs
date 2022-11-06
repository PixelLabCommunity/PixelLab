using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemiesPrefab;
    [SerializeField] private GameObject _extraLifePrefab;

    private float _spawnEnemiesX = 22.0f;
    private float _spawnEnemiesY = 1.1f;
    private float _spawnEnemiesZ = 14.0f;
    private int _enemiesSpawnCountMin = 0;

    private float _spawnExtraLifeX = 18.0f;
    private float _spawnExtraLifeY = 1.1f;
    private float _spawnExtraLifeZMax = 2.87f;
    private float _spawnExtraLifeZMin = -8.12f;

    private float _spawnDelay = 1.0f;
    private float _spawnEnemiesSec = 3.0f;
    private float _spawnExtraLifeSec = 5.0f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemies", _spawnDelay, _spawnEnemiesSec);
        InvokeRepeating("SpawnExtraLife", _spawnDelay, _spawnExtraLifeSec);
    }

    private void Update()
    {
    }

    private void SpawnEnemies()
    {
        float _enemiesSpawnRandX = Random.Range(-_spawnEnemiesX, _spawnEnemiesX);
        int _enemiesSpawnCount = Random.Range(_enemiesSpawnCountMin, _enemiesPrefab.Length);

        Vector3 _enemiesSpawnPos = new Vector3(_enemiesSpawnRandX, _spawnEnemiesY,
            _spawnEnemiesZ);

        Instantiate(_enemiesPrefab[_enemiesSpawnCount], _enemiesSpawnPos,
            _enemiesPrefab[_enemiesSpawnCount].transform.rotation);
    }

    private void SpawnExtraLife()
    {
        float _extraLifeSpawnRandX = Random.Range(-_spawnExtraLifeX, _spawnExtraLifeX);
        float _extraLifeSpawnRandZ = Random.Range(_spawnExtraLifeZMin, _spawnExtraLifeZMax);

        Vector3 _extraLifeSpawnPos = new Vector3(_extraLifeSpawnRandX, _spawnExtraLifeY,
            _extraLifeSpawnRandZ);

        Instantiate(_extraLifePrefab, _extraLifeSpawnPos, _extraLifePrefab.transform.rotation);
    }
}