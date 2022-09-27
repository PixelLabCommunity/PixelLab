using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerMovement2D : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _checkGround;
        [SerializeField] private float _checkJumpRadius;
        [SerializeField] private LayerMask _whatIsGround;
        [SerializeField] private float _jumpForce;

        private Rigidbody2D _rb;
        private float _input;
        private bool isFacingRight = true;
        private bool isGrounded;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            isGrounded = Physics2D.OverlapCircle(_checkGround.position, _checkJumpRadius, _whatIsGround);
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            {
                _rb.velocity = Vector2.up * _jumpForce;
            }
        }

        private void FixedUpdate()
        {
            _input = Input.GetAxisRaw("Horizontal");
            _rb.velocity = new Vector2(_input * _speed, _rb.velocity.y);

            if (_input > 0 && isFacingRight == false)
            {
                Flip();
            }
            else if (_input < 0 && isFacingRight == true)
            {
                Flip();
            }
        }

        private void Flip()
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFacingRight = !isFacingRight;
        }
    }
}