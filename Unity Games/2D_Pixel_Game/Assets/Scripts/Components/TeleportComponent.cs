using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components
{
    public class TeleportComponent : MonoBehaviour
    {
        [SerializeField] private Transform _targetPosition;

        protected void Teleport(GameObject target)
        {
            target.transform.position = _targetPosition.position;
        }
    }
}