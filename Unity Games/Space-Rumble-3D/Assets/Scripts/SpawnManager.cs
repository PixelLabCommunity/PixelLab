using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    private Vector3 _spawnEnemyPosition;

    private float _spawnRange = 9.0f;
    private float _enemySpawnY = 0.12f;

    private void Awake()
    {
        float _randomSpawnX = Random.Range(-_spawnRange, _spawnRange);
        float _randomSpawnZ = Random.Range(-_spawnRange, _spawnRange);

        _spawnEnemyPosition = new Vector3(_randomSpawnX, _enemySpawnY, _randomSpawnZ);
    }

    private void Start()
    {
        Instantiate(_enemyPrefab, _spawnEnemyPosition, _enemyPrefab.transform.rotation);
    }
}