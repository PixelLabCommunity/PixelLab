using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnTargets;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private float _spawnTime = 1.0f;
    private int _spawnCountMin = 0;
    private int _score = 0;
    private int _scoreOnStart = 0;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(_scoreOnStart);
    }

    private IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);
            int _randPrefab = Random.Range(_spawnCountMin, _spawnTargets.Count);
            Instantiate(_spawnTargets[_randPrefab]);
            UpdateScore(5);
        }
    }

    private void UpdateScore(int _scoreToAdd)
    {
        _score += _scoreToAdd;
        _scoreText.text = "Score: " + _score;
    }
}