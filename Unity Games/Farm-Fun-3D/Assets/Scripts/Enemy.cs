using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _pointValue;
    [SerializeField] private GameObject _spawnTextPrefab;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        SpawnText();
        _gameManager.UpdateScore(_pointValue);
        Destroy(gameObject);
        Destroy(other.gameObject);

        
    }

    private void SpawnText()
    {
        // Instantiate the spawn text prefab
        GameObject _spawnText = Instantiate(_spawnTextPrefab, transform.position, Quaternion.Euler(90f, 0f, 0f));

        // Destroy the spawn text after 2 seconds
        Destroy(_spawnText, 2f);
    }


}
