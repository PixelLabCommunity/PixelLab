using Scripts.Components;
using UnityEngine;

namespace Scripts
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _damageJumpSpeed;
        [SerializeField] private LayerCheck _groundCheck;
        [SerializeField] private float _interactionRadius;
        [SerializeField] private LayerMask _interactionLayerMask;
        [SerializeField] private SpawnComponent _footStepParticle;
        [SerializeField] private SpawnComponent _jumpEffectParticle;
        [SerializeField] private SpawnComponent _fallEffectParticle;
        [SerializeField] private ParticleSystem _hitParticle;

        private Collider2D[] _interactionResult = new Collider2D[1];
        private bool _isGrounded;
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private Animator _animator;
        private bool _allowDoubleJump;
        private bool _allowFallGroundSpawnEffect;
        private int _coins;

        private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
        private static readonly int IsRunningKey = Animator.StringToHash("is-running");
        private static readonly int VerticalVelocityKey = Animator.StringToHash("vertical-velocity");
        private static readonly int Hit = Animator.StringToHash("hit");

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        private void FixedUpdate()
        {
            var xVelocity = _direction.x * _speed;
            var yVelocity = CalculateYVelovity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);
            // Animation
            _animator.SetBool(IsGroundKey, _isGrounded);
            _animator.SetBool(IsRunningKey, _direction.x != 0);
            _animator.SetFloat(VerticalVelocityKey, _rigidbody.velocity.y);
            UpdateSpriteDirection();
        }

        private float CalculateYVelovity()
        {
            var isJumpPressing = _direction.y > 0;
            var yVelocity = _rigidbody.velocity.y;

            if (_isGrounded)
            {
                _allowDoubleJump = true;
            }

            if (isJumpPressing)
            {
                yVelocity = CalculateJumpVelovity(yVelocity);
                if (_isGrounded && _rigidbody.velocity.y <= 0.001f)
                {
                    _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                }
            }
            else if (_rigidbody.velocity.y > 0)
            {
                yVelocity *= 0.5f;
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
            }

            return yVelocity;
        }

        private float CalculateJumpVelovity(float yVelocity)
        {
            var isFalling = _rigidbody.velocity.y <= 0.001f;
            if (!isFalling) return yVelocity;

            if (_isGrounded)
            {
                yVelocity += _jumpSpeed;
                SpawnJumpEffect();
            }
            else if (_allowDoubleJump)
            {
                yVelocity = _jumpSpeed;
                _allowDoubleJump = false;
            }

            return yVelocity;
        }

        private void Update()
        {
            _isGrounded = IsGrounded();
            if (!_allowDoubleJump && _isGrounded && _allowFallGroundSpawnEffect)
            {
                SpawnGroundEffect();
            }
        }

        /// <summary>
        /// Flip direction
        /// </summary>
        private void UpdateSpriteDirection()
        {
            if (_direction.x > 0)
            {
                transform.localScale = Vector3.one;
            }
            else if (_direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        private bool IsGrounded()
        {
            return _groundCheck.IsTouchingLayer;
        }

        public void TakeDamage()
        {
            _animator.SetTrigger(Hit);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageJumpSpeed);
            SpawnCoins();
        }

        public void SpawnCoins()
        {
            _hitParticle.gameObject.SetActive(true);
            _hitParticle.Play();
        }

        public void AddCoins(int coins)
        {
            _coins += coins;
            Debug.Log($"{coins} coins added. Total coins: {_coins}");
        }

        public void Interact()
        {
            var size = Physics2D.OverlapAreaNonAlloc(transform.position,
                transform.position * _interactionRadius,
                _interactionResult, _interactionLayerMask);
            for (int i = 0; i < size; i++)
            {
                var interactable = _interactionResult[i].GetComponent<InteractableComponent>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }

        public void SpawnFootDust()
        {
            _footStepParticle.Spawn();
        }

        public void SpawnJumpEffect()
        {
            _jumpEffectParticle.SpawnJumpEffect();
            _allowFallGroundSpawnEffect = true;
        }

        public void SpawnGroundEffect()
        {
            _fallEffectParticle.SpawnGroundEffect();
        }
    }
}