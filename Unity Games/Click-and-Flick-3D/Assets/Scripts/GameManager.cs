using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnTargets;

    private float _spawnTime = 1.0f;
    private int _spawnCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);
            int _randPrefab = Random.Range(_spawnCount, _spawnTargets.Count);
            Instantiate(_spawnTargets[_randPrefab]);
        }
    }
}