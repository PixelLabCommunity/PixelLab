using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 2.0f;
    private float spawnInterval = 1.5f;

    private PlayerControllerX playerControllerScript;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").
            GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    private void SpawnObjects()
    {
        // Set random spawn location and random object _index
        Vector3 _spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
        int _index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (!playerControllerScript._gameOver)
        {
            Instantiate(objectPrefabs[_index], _spawnLocation,
                objectPrefabs[_index].transform.rotation);
        }
    }
}