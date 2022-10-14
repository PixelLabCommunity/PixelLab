using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    [SerializeField] private GameObject[] _ballPrefabs;

    private float _spawnLimitXLeft = -22.0f;
    private float _spawnLimitXRight = 7.0f;
    private float _spawnPosY = 30.0f;

    private float _startDelay = 1.0f;
    private float _spawnInterval = 4.0f;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnRandomBall", _startDelay, _spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    private void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(_spawnLimitXLeft, _spawnLimitXRight),
            _spawnPosY, transform.position.z);

        // instantiate ball at random spawn location
        int _balltype = Random.Range(0, _ballPrefabs.Length);
        Instantiate(_ballPrefabs[_balltype], spawnPos, _ballPrefabs[_balltype].transform.rotation);
    }
}