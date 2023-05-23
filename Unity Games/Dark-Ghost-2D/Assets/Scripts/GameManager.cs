using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private List<GameObject> _spawnTargets;
    [SerializeField] private float _spawnTime = 10.0f;


    private int _coins = 0;
    private int _coinsOnStart = 0;

    private int _spawnCoinsMin = 0;

    private bool _gameStart;


    private void Start()
    {
        _gameStart = true;
        UpdateScoreCoins(_coinsOnStart);
        StartCoroutine(SpawnTarget());
    }

    public void UpdateScoreCoins(int _coinsToAdd)
    {
        _coins += _coinsToAdd;
        _coinsText.text = "Coins: " + _coins;

    }
    private IEnumerator SpawnTarget()
    {
        while (_gameStart)
        {
            yield return new WaitForSeconds(_spawnTime);
            int _randPrefab = Random.Range(_spawnCoinsMin, _spawnTargets.Count);
            Instantiate(_spawnTargets[_randPrefab]);
        }
    }

}