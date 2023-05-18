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
        [SerializeField] private FixedJoystick _joystick;

        private Rigidbody2D _rb;
        private float _input;
        private bool _isFacingRight = true;
        private bool _isGrounded;
        private float _jumpTimeCounter;
        private bool _isJumping;
        private bool _isChargingJump;
        private bool _canDoubleJump = true;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            ChargeJump();
        }

        private void FixedUpdate()
        {
            _input = _joystick.Horizontal;
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

        public void JumpButton()
        {
            _isGrounded = Physics2D.OverlapCircle(_checkGround.position, _checkJumpRadius, _whatIsGround);

            if (_isGrounded)
            {
                _isJumping = true;
                _jumpTimeCounter = _jumpTime;
                _rb.velocity = Vector2.up * _jumpForce;
            }
            else if (_canDoubleJump)
            {
                _isJumping = true;
                _canDoubleJump = false;
                _jumpTimeCounter = _jumpTime;
                _rb.velocity = Vector2.up * _jumpForce;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isJumping = false;
                _canDoubleJump = true;
            }
        }

        private void Flip()
        {
            transform.Rotate(0f, 180f, 0f);
            _isFacingRight = !_isFacingRight;
        }

        // Reserve
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