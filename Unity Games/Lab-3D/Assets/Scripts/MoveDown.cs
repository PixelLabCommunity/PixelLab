using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;

    private Rigidbody _enemyRB;
    private float _positionBoundZ = -15.0f;

    private void Start()
    {
        _enemyRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _enemyRB.AddForce(Vector3.forward * -_enemySpeed);

        DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        if (transform.position.z < _positionBoundZ)
        {
            Destroy(gameObject);
        }
    }
    
}