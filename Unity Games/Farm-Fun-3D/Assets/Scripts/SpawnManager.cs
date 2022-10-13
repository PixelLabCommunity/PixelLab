using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _animalPrefabs;

    private float _spawnRangeX = 15.0f;
    private float _spawnPosZ = 20.0f;
    private float _startDelay = 2.0f;
    private float _repeatInterval = 1.5f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", _startDelay, _repeatInterval);
    }

    private void Update()
    {
    }

    private void SpawnRandomAnimal()
    {
        // Random spawn animals in axes X
        Vector3 _spawnPos = new(Random.Range(-_spawnRangeX, _spawnRangeX),
            transform.position.y, _spawnPosZ);

        // Random spawn animals types
        int _animalsIndex = Random.Range(0, _animalPrefabs.Length);
        Instantiate(_animalPrefabs[_animalsIndex], _spawnPos,
            _animalPrefabs[_animalsIndex].transform.rotation);
    }
}