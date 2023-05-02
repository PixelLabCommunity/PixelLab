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
    [SerializeField] private TextMeshProUGUI _failedText;
    [SerializeField] private TextMeshProUGUI _failedMaxText;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _titleScreen;

    [SerializeField] private int _goodFailedMax = 5;
    [SerializeField] private float _spawnTime = 5.0f;

    private int _spawnCountMin = 0;
    private int _score = 0;
    private int _scoreOnStart = 0;
    private int _goodFailed = 0;
    private int _goodFailedOnStart = 0;

    public bool _isGameStart;

    private void Update()
    {
        GamePaused();
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
        if (_score < _scoreOnStart)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        _gameOverScreen.gameObject.SetActive(true);
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
        UpdateFailed(_goodFailedOnStart);
        _titleScreen.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UpdateFailed(int _failedAdd)
    {
        _goodFailed += _failedAdd;
        _failedText.text = "Failed: " + _goodFailed;
        _failedMaxText.text = "of " + _goodFailedMax;

        if (_goodFailed == _goodFailedMax)
        {
            GameOver();
        }
    }

    private void GamePaused()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RestartGame();
        }
    }
}