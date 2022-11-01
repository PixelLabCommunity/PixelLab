using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _powerUpPrefab;
    [SerializeField] private int _enemiesCountMin = 1;

    private Vector3 _spawnEnemyPosition;

    private float _spawnRange = 9.0f;
    private float _enemySpawnY = 0.12f;
    private int _waveNumber = 1;

    private void Start()
    {
        SpawnEnemyWave(_waveNumber);
        SpawnPowerUp();
    }

    private void Update()
    {
        _enemiesCountMin = FindObjectsOfType<Enemy>().Length;
        if (_enemiesCountMin == 0)
        {
            _waveNumber++;
            SpawnEnemyWave(_waveNumber);
            SpawnPowerUp();
        }
    }

    private void SpawnEnemyWave(int enemiesSpawnCount)
    {
        for (int i = 0; i < enemiesSpawnCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, GenerateSpawnEnemy(),
                _enemyPrefab.transform.rotation);
    }

    private void SpawnPowerUp()
    {
        Instantiate(_powerUpPrefab, GenerateSpawnEnemy(),
                _enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnEnemy()
    {
        float _randomSpawnX = Random.Range(-_spawnRange, _spawnRange);
        float _randomSpawnZ = Random.Range(-_spawnRange, _spawnRange);

        _spawnEnemyPosition = new Vector3(_randomSpawnX, _enemySpawnY, _randomSpawnZ);

        return _spawnEnemyPosition;
    }
}