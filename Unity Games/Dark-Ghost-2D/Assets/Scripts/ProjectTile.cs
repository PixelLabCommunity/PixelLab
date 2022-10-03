using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class ProjectTile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _lifetime;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = transform.right * _speed;
            Invoke("DestroyTile", _lifetime);
        }

        private void DestroyTile()
        {
            Destroy(gameObject);
        }
    }
}