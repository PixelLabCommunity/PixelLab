using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    private Vector3 _spawnEnemyPosition;

    private float _spawnRange = 9.0f;
    private float _enemySpawnY = 0.12f;

    private void Start()
    {
        SpawnEnemyWave();
    }

    private void SpawnEnemyWave()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_enemyPrefab, GenerateSpawnEnemy(), _enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateSpawnEnemy()
    {
        float _randomSpawnX = Random.Range(-_spawnRange, _spawnRange);
        float _randomSpawnZ = Random.Range(-_spawnRange, _spawnRange);

        _spawnEnemyPosition = new Vector3(_randomSpawnX, _enemySpawnY, _randomSpawnZ);

        return _spawnEnemyPosition;
    }
}