using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Camera : MonoBehaviour
    {
        [SerializeField] private GameObject _player;

        private Vector3 _position;

        private void Start()
        {
            _position = transform.position - _player.transform.position;
        }

        private void LateUpdate()
        {
            transform.position = _player.transform.position + _position;
        }
    }
}