using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _pos1, _pos2;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _startPos;

    private Vector3 _nextPos;

    private void Start()
    {
        _nextPos = _startPos.position;
    }

    private void Update()
    {
        if (transform.position == _pos1.position)
        {
            _nextPos = _pos2.position;
        }
        if (transform.position == _pos2.position)
        {
            _nextPos = _pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, _nextPos, _speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_pos1.position, _pos2.position);
    }
}