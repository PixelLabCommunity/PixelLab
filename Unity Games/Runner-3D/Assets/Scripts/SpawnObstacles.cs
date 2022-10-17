using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstaclePrefabs;
    private Vector3 _spawnObstacles = new Vector3(19.85f, 0.0f, 0.0f);

    private void Start()
    {
        int _spawnPrefabs = Random.Range(0, _obstaclePrefabs.Length);
        Instantiate(_obstaclePrefabs[_spawnPrefabs], _spawnObstacles,
            _obstaclePrefabs[_spawnPrefabs].transform.rotation);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}