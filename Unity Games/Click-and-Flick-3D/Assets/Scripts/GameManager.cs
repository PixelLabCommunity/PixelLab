using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnTargets;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _titleScreen;

    private float _spawnTime = 1.0f;
    private int _spawnCountMin = 0;
    private int _score = 0;
    private int _scoreOnStart = 0;

    public bool _isGameStart;

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
        _restartButton.gameObject.SetActive(true);
        _gameOverText.gameObject.SetActive(true);
        _isGameStart = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int _difficulty)
    {
        _isGameStart = true;
        _spawnTime /= _difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(_scoreOnStart);
        _titleScreen.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}