using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformPrefab;

    private float _spawnUpY = 15.0f;
    private float _spawnDownY = -9.0f;
    private float _spawnLeftX = -12.0f;
    private float _spawnRightX = 25.0f;

    private float _startDelay = 2.0f;
    private float _repeatInterval = 10.0f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomPlatform", _startDelay, _repeatInterval);
    }

    private void SpawnRandomPlatform()
    {
        Vector2 _spawnPos = new(Random.Range(_spawnLeftX, _spawnRightX),
            Random.Range(_spawnUpY, _spawnDownY));

        int _platformIndex = Random.Range(0, _platformPrefab.Length);
        Instantiate(_platformPrefab[_platformIndex], _spawnPos, _platformPrefab[_platformIndex].transform.rotation);
    }
}