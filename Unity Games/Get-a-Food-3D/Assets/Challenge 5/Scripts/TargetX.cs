using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetX : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private GameManagerX _gameManagerX;
    public int _pointValue;
    public GameObject _explosionFx;

    public float _timeOnScreen = 1.0f;

    private float _minValueX = -3.75f; // the x value of the center of the left-most square
    private float _minValueY = -3.75f; // the y value of the center of the bottom-most square
    private float _spaceBetweenSquares = 2.5f; // the distance between the centers of squares on the game board

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();

        transform.position = RandomSpawnPosition();
        StartCoroutine(RemoveObjectRoutine()); // begin timer before target leaves screen
    }

    // When target is clicked, destroy it, update _score, and generate explosion
    private void OnMouseDown()
    {
        if (_gameManagerX._isGameActive)
        {
            Destroy(gameObject);
            _gameManagerX.UpdateScore(_pointValue);
            Explode();
        }
    }

    // Generate a random spawn position based on a random index from 0 to 3
    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = _minValueX + (RandomSquareIndex() * _spaceBetweenSquares);
        float spawnPosY = _minValueY + (RandomSquareIndex() * _spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;
    }

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    private int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // If target that is NOT the bad object collides with sensor, trigger game over
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Sensor") && !gameObject.CompareTag("Bad"))
        {
            _gameManagerX.GameOver();
        }
    }

    // Display explosion particle at object's position
    private void Explode()
    {
        Instantiate(_explosionFx, transform.position, _explosionFx.transform.rotation);
    }

    // After a delay, Moves the object behind background so it collides with the Sensor object
    private IEnumerator RemoveObjectRoutine()
    {
        yield return new WaitForSeconds(_timeOnScreen);
        if (_gameManagerX._isGameActive)
        {
            transform.Translate(Vector3.forward * 5, Space.World);
        }
    }
}