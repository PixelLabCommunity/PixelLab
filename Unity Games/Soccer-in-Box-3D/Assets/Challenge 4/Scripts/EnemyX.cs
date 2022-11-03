using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float _enemySpeed;

    private GameObject _playerGoal;
    private Rigidbody _enemyRb;

    // Start is called before the first frame update
    private void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _playerGoal = GameObject.Find("Player Goal");
    }

    // Update is called once per frame
    private void Update()
    {
        // Set enemy direction towards _player goal and move there
        Vector3 lookDirection = _playerGoal.transform.position - transform.position;
        _enemyRb.AddForce(lookDirection * _enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }
    }
}