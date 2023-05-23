using System.Collections;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private int _pointValue;
    [SerializeField] private float _lifeTime = 5.0f;
    [SerializeField] private GameObject _coinParticlePrefab;
    

    private GameManager _gameManager;

    private Vector2[] _spawnPositions = {
        new Vector2(-0.17f, -0.12f),
        new Vector2(15.26f, 3.95f),
        new Vector2(-10.22f, 11.53f),
        new Vector2(15.26f, 13.5f)
    };


    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        SpawnPosition();
        Invoke("CoinLife", _lifeTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameManager.UpdateScoreCoins(_pointValue);
            PlayCoinParticle();
            Destroy(gameObject);
        }
    }

    private void SpawnPosition()
    {
        int randomIndex = Random.Range(0, _spawnPositions.Length);
        Vector2 randomSpawnPosition = _spawnPositions[randomIndex];
        transform.position = randomSpawnPosition;
    }

    private void CoinLife()
    {
        Destroy(gameObject);
    }

    private void PlayCoinParticle()
    {
        GameObject coinParticle = Instantiate(_coinParticlePrefab, transform.position, Quaternion.identity);
        ParticleSystem particleSystem = coinParticle.GetComponent<ParticleSystem>();
        particleSystem.Play();
        Destroy(coinParticle, particleSystem.main.duration);
    }
}
