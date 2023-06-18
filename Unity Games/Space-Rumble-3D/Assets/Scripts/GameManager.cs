using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefab;

    [SerializeField]
    private GameObject[] _powerUpPrefab;

    [SerializeField]
    private GameObject _bossPrefab;

    [SerializeField]
    private int _enemiesCountMin = 1;

    [SerializeField]
    private int _number;

    private Vector3 _spawnEnemyPosition;

    private float _spawnRange = 9.0f;
    private float _enemySpawnY = 0.12f;
    private int _waveNumber = 1;
    private int _bossSpawnEvent = 4;

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
        if (enemiesSpawnCount == _bossSpawnEvent)
        {
            SpawnBoss();
        }
    }

    private void SpawnEnemy()
    {
        int randPrefab = Random.Range(0, _enemyPrefab.Length);

        Instantiate(
            _enemyPrefab[randPrefab],
            GenerateSpawnEnemy(),
            _enemyPrefab[randPrefab].transform.rotation
        );
    }

    private void SpawnBoss()
    {
        Instantiate(_bossPrefab, GenerateSpawnEnemy(), _bossPrefab.transform.rotation);
        SpawnEnemy();
    }

    private void SpawnPowerUp()
    {
        int randPrefab = Random.Range(0, _enemyPrefab.Length);
        int randPowerUpPrefab = Random.Range(0, _powerUpPrefab.Length);
        Instantiate(
            _powerUpPrefab[randPowerUpPrefab],
            GenerateSpawnEnemy(),
            _enemyPrefab[randPrefab].transform.rotation
        );
    }

    private Vector3 GenerateSpawnEnemy()
    {
        float _randomSpawnX = Random.Range(-_spawnRange, _spawnRange);
        float _randomSpawnZ = Random.Range(-_spawnRange, _spawnRange);

        _spawnEnemyPosition = new Vector3(_randomSpawnX, _enemySpawnY, _randomSpawnZ);

        return _spawnEnemyPosition;
    }
}
