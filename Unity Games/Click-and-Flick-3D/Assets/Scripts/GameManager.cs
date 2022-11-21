using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnTargets;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private AudioSource _badSound;

    private float _spawnTime = 1.0f;
    private int _spawnCountMin = 0;
    private int _score = 0;
    private int _scoreOnStart = 0;

    public bool _isGameStart;

    private void Start()
    {
        _isGameStart = true;
        _badSound = GetComponent<AudioSource>();
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
        _restartButton.gameObject.SetActive(true);
        _gameOverText.gameObject.SetActive(true);
        _isGameStart = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnMouseDown()
    {
        if (_isGameStart)
        {
            if (gameObject.CompareTag("Bad"))
            {
                _badSound.Play();
            }
        }
    }
}