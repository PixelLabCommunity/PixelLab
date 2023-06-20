using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnLemonController : MonoBehaviour
{
    public Animator _animator;
    public Transform _targetPosition;
    public float _moveSpeed = 2f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _targetPosition = new GameObject("TargetPosition").transform;
        _targetPosition.position = new Vector3(2.957f, 0f, 5.615f);
    }

    private void Update()
    {
        if (transform.position != _targetPosition.position)
        {
            _animator.SetBool("isWalking", true);
            transform.position = Vector3.MoveTowards(
                transform.position,
                _targetPosition.position,
                _moveSpeed * Time.deltaTime
            );
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            _animator.SetBool("isWalking", false);
            transform.rotation = Quaternion.identity;
        }
    }
}
