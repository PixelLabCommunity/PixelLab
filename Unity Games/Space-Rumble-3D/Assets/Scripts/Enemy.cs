using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;

    private Rigidbody _enemyRb;
    private GameObject _playerGo;

    private void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _playerGo = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 _enemyGoDirection = (_playerGo.transform.position -
                                                       transform.position).normalized;
        _enemyRb.AddForce(_enemyGoDirection * _speed);
    }
}