using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private float _groundCheckRadius;

    private Rigidbody2D _rigidbody;
    private Vector2 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);
        var isJumping = _direction.y > 0;
        if (isJumping && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, 1, _groundLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector3.down, IsGrounded() ? Color.green : Color.red);
    }
}