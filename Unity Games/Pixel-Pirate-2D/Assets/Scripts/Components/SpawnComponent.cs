using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;

        public void Spawn()
        {
            var instantiate = Instantiate(_prefab, _target.position, Quaternion.identity);
            instantiate.transform.localScale = _target.lossyScale;
        }

        public void SpawnJumpEffect()
        {
            Instantiate(_prefab, _target);
        }

        [ContextMenu("SpawnGroundEffect_PrefabTest")]
        public void SpawnGroundEffect()
        {
            Instantiate(_prefab, _target);
        }
    }
}