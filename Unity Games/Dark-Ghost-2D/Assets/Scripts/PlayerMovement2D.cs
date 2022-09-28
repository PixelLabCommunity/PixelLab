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
        [SerializeField] private float _jumpTime;
        [SerializeField] private int _extraJumpValue;
        [SerializeField] private float _extraJumpForce;
        [SerializeField] private float _chargeJumpForce;
        [SerializeField] private float _chargeJumpSpeed;
        [SerializeField] private float _chargeJumpTime;

        private Rigidbody2D _rb;
        private float _input;
        private bool _isFacingRight = true;
        private bool _isGrounded;
        private float _jumpTimeCounter;
        private bool _isJumping;
        private int _extraJump;
        private bool _isChargingJump;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _isGrounded = Physics2D.OverlapCircle(_checkGround.position, _checkJumpRadius, _whatIsGround);
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
            {
                _isJumping = true;
                _jumpTimeCounter = _jumpTime;
                _rb.velocity = Vector2.up * _jumpForce;
            }
            if (Input.GetKey(KeyCode.Space) && _isJumping == true)
            {
                if (_jumpTimeCounter > 0)
                {
                    _rb.velocity = Vector2.up * _jumpForce;
                    _jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    _isJumping = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _isJumping = false;
            }
            ExtraJump();
            ChargeJump();
        }

        private void FixedUpdate()
        {
            _input = Input.GetAxisRaw("Horizontal");
            _rb.velocity = new Vector2(_input * _speed, _rb.velocity.y);

            if (_input > 0 && _isFacingRight == false)
            {
                Flip();
            }
            else if (_input < 0 && _isFacingRight == true)
            {
                Flip();
            }
        }

        private void Flip()
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            _isFacingRight = !_isFacingRight;
        }

        private void ExtraJump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _extraJump > 0 && _isGrounded == false)
            {
                _rb.velocity = Vector2.up * _extraJumpForce;
                _extraJump--;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && _extraJump == 0 && _isGrounded == true)
            {
                _rb.velocity = Vector2.up * _jumpForce;
            }
            if (_isGrounded == true)
            {
                _extraJump = _extraJumpValue;
            }
        }

        private void ChargeJump()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                _chargeJumpTime = 0;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) && _chargeJumpTime < 5 && _isGrounded == true)
            {
                _isChargingJump = true;
                if (_isChargingJump == true)
                {
                    _chargeJumpTime += Time.deltaTime * _chargeJumpSpeed;
                }
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) && _chargeJumpTime >= 5)
            {
                _rb.velocity = Vector2.up * _chargeJumpForce;
                _isChargingJump = false;
                _chargeJumpTime = 0;
            }
        }
    }
}