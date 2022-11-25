using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI _timeText;
    public TextMeshProUGUI _gameOverText;
    public GameObject _titleScreen;
    public Button _restartButton;
    public List<GameObject> _targetPrefabs;

    public bool _isGameActive;

    private int _scoreOnStart = 0;
    private int _score = 0;
    private float _spawnRate = 3.0f;
    private int _minPrefab = 0;
    private float _spawnPosZ = 0;
    private int _randSquareMin = 0;
    private int _randSquareMax = 4;
    private float _timeDown = 60;

    private float _spaceBetweenSquares = 2.5f;
    private float _minValueX = -3.75f; //  x value of the center of the left-most square
    private float _minValueY = -3.75f; //  y value of the center of the bottom-most square

    private void Update()
    {
        UpdateTime();
    }

    // Start the game, remove title screen, reset _score, and adjust _spawnRate based on _difficulty _button clicked
    public void StartGame(int _difficulty)
    {
        _spawnRate /= _difficulty;
        _isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(_scoreOnStart);
        _titleScreen.SetActive(false);
    }

    // While game is active spawn a random target
    private IEnumerator SpawnTarget()
    {
        while (_isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(_minPrefab, _targetPrefabs.Count);

            if (_isGameActive)
            {
                Instantiate(_targetPrefabs[index], RandomSpawnPosition(), _targetPrefabs[index].transform.rotation);
            }
        }
    }

    // Generate a random spawn position based on a random index from 0 to 3
    private Vector3 RandomSpawnPosition()
    {
        float _spawnPosX = _minValueX + (RandomSquareIndex() * _spaceBetweenSquares);
        float _spawnPosY = _minValueY + (RandomSquareIndex() * _spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(_spawnPosX, _spawnPosY, _spawnPosZ);
        return spawnPosition;
    }

    // Generates random square index from 0 to 3,
    // which determines which square the target will appear in
    private int RandomSquareIndex()
    {
        return Random.Range(_randSquareMin, _randSquareMax);
    }

    // Update _score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        _scoreText.text = "Score: " + _score;
    }

    // Stop game, bring up game over text and restart _button
    public void GameOver()
    {
        _gameOverText.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
        _isGameActive = false;
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Update count down time when game running
    public void UpdateTime()
    {
        if (_isGameActive)
        {
            _timeDown -= Time.deltaTime;
            _timeText.text = "Time: " + Mathf.Round(_timeDown);
            if (_timeDown <= 0)
            {
                GameOver();
            }
        }
    }
}