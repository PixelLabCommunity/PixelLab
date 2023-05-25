using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _spawnTextPrefab;
    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private int _pointValue;

    [SerializeField] private AudioClip _pointSound;
    [SerializeField] private List<string> _spawnTextOptions;
   

    private AudioSource _playerAudioSource;
    private GameManager _gameManager;
    private float _spawnTextTimer = 2f;
    private Vector3 _spawnTextRotation = new Vector3(90f, 0f, 0f);

    private void Start()
    {
        _playerAudioSource = GameObject.Find("Main Music").GetComponent<AudioSource>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        SpawnText(_pointValue);
        _playerAudioSource.PlayOneShot(_pointSound);
        SpawnParticle();
        _gameManager.UpdateScore(_pointValue);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }

    private void SpawnText(int pointValue)
    {
        GameObject _spawnTextObject = Instantiate(_spawnTextPrefab, transform.position, Quaternion.Euler(_spawnTextRotation));
        TextMeshPro _textMesh = _spawnTextObject.GetComponent<TextMeshPro>();

        if (_textMesh != null)
        {
            string _randomText = _spawnTextOptions[Random.Range(0, _spawnTextOptions.Count)];
            _textMesh.text = "+ " + _pointValue + " " + _randomText + " ";
        }

        Destroy(_spawnTextObject, _spawnTextTimer);
    }

    private void SpawnParticle()
    {
        Instantiate(_explosionParticle, transform.position, transform.rotation);
    }
}