using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePrefabs;
    private PlayerControls _playerControlsScript;

    private Vector3 _spawnObstacles = new Vector3(19.85f, 0.0f, 0.0f);
    private float _startDelay = 2.0f;
    private float _repeatRange = 2.0f;

    private void Start()
    {
        _playerControlsScript = GameObject.Find("Player").
            GetComponent<PlayerControls>();
        InvokeRepeating("SpawnPrefabs", _startDelay, _repeatRange);
    }

    private void SpawnPrefabs()
    {
        if (_playerControlsScript._gameOver == false)
        {
            int _spawnPrefabs = Random.Range(0, _obstaclePrefabs.Length);
            Instantiate(_obstaclePrefabs[_spawnPrefabs], _spawnObstacles,
                _obstaclePrefabs[_spawnPrefabs].transform.rotation);
        }
    }
}