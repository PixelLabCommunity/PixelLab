using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnObstaclePrefab;

    private Vector3 _spawnObstaclePosition;
    private float _spawnValueX = 5.0f;
    private float _spawnObstaclePositionY = 0.0f;
    private float _spawnObstaclePositionZ = 97.0f;
    private float _spawnDelay = 2.0f;
    private float _repeatSpawn = 6.0f;

    private void Start()
    {
        InvokeRepeating("SpawnObstaclePrefab", _spawnDelay, _repeatSpawn);
    }

    private void Update()
    {
        float _spawnObstacleRandomX = Random.Range(-_spawnValueX, _spawnValueX);
        _spawnObstaclePosition = new Vector3(_spawnObstacleRandomX,
            _spawnObstaclePositionY, _spawnObstaclePositionZ);
    }

    private void SpawnObstaclePrefab()
    {
        int _obstaclePrefabRandom = Random.Range(0, _spawnObstaclePrefab.Length);
        Instantiate(_spawnObstaclePrefab[_obstaclePrefabRandom], _spawnObstaclePosition,
            _spawnObstaclePrefab[_obstaclePrefabRandom].transform.rotation);
    }
}