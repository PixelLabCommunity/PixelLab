using UnityEngine;

namespace Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _lifetime;
        [SerializeField] private int _damage = 5;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = transform.right * _speed;
            Invoke("BulletLife", _lifetime);
        }

        private void BulletLife()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.Damage(_damage);
                }

                Destroy(gameObject);
            }
        }
    }
}
