using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _animalPrefabs;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            int _animalsIndex = Random.Range(0, _animalPrefabs.Length);
            Instantiate(_animalPrefabs[_animalsIndex], new Vector3(transform.position.x, transform.position.y, 20),
                _animalPrefabs[_animalsIndex].transform.rotation);
        }
    }
}