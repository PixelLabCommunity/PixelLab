using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _animalPrefabs;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _gameOverScreen;

    private int _score = 0;
    private int _scoreOnStart = 0;
    private float _spawnRangeX = 15.0f;
    private float _spawnPosZ = 20.0f;
    private float _startDelay = 2.0f;
    private float _repeatInterval = 1.5f;

    public bool _isGameStart;

    private void Start()
    {
        _isGameStart = true;
        UpdateScore(_scoreOnStart);
        InvokeRepeating("SpawnRandomAnimal", _startDelay, _repeatInterval);
    }

    private void Update()
    {
    }

    private void SpawnRandomAnimal()
    {
        Vector3 _spawnPos = new(Random.Range(-_spawnRangeX, _spawnRangeX),
            transform.position.y, _spawnPosZ);

        int _animalsIndex = Random.Range(0, _animalPrefabs.Length);
        Instantiate(_animalPrefabs[_animalsIndex], _spawnPos,
            _animalPrefabs[_animalsIndex].transform.rotation);
    }

    public void UpdateScore(int _scoreToAdd)
    {
        _score += _scoreToAdd;
        _scoreText.SetText("Score: " + _score);

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
}