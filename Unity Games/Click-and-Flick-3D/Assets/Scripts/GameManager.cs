using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnTargets;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverText;

    private float _spawnTime = 1.0f;
    private int _spawnCountMin = 0;
    private int _score = 0;
    private int _scoreOnStart = 0;

    public bool _isGameStart;

    private void Start()
    {
        _isGameStart = true;

        StartCoroutine(SpawnTarget());
        UpdateScore(_scoreOnStart);
    }

    private IEnumerator SpawnTarget()
    {
        while (_isGameStart)
        {
            yield return new WaitForSeconds(_spawnTime);
            int _randPrefab = Random.Range(_spawnCountMin, _spawnTargets.Count);
            Instantiate(_spawnTargets[_randPrefab]);
        }
    }

    public void UpdateScore(int _scoreToAdd)
    {
        _score += _scoreToAdd;
        _scoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        _gameOverText.gameObject.SetActive(true);
        _isGameStart = false;
    }
}