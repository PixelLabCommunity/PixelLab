using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject _enemyPrefab;
    public GameObject _powerUpPrefab;

    private float _spawnRangeX = 10;
    private float _spawnZMin = 15; // set min spawn Z
    private float _spawnZMax = 25; // set max spawn Z
    private EnemyX _enemySpeed;
    private Vector3 _powerupSpawnOffset = new Vector3(0, 0, -15);

    public int _enemyCount;
    public int _waveCount = 1;

    public GameObject _player;

    // Update is called once per frame
    private void Update()
    {
        _enemyCount = FindObjectsOfType<EnemyX>().Length;

        if (_enemyCount == 0)
        {
            SpawnEnemyWave(_waveCount);
        }
    }

    // Generate random spawn position for powerups and enemy balls
    private Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-_spawnRangeX, _spawnRangeX);
        float zPos = Random.Range(_spawnZMin, _spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0)
        {
            Instantiate(_powerUpPrefab, GenerateSpawnPosition() +
                _powerupSpawnOffset, _powerUpPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < _waveCount; i++)
        {
            EnemyX enemy = Instantiate(_enemyPrefab, GenerateSpawnPosition(),
                _enemyPrefab.transform.rotation).GetComponent<EnemyX>();
            enemy._enemySpeed += _waveCount;
        }

        _waveCount++;
        ResetPlayerPosition(); // put _player back at start
    }

    // Move _player back to position in front of own goal
    private void ResetPlayerPosition()
    {
        _player.transform.position = new Vector3(0, 1, -7);
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}