using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _lifetime;

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
    }
}