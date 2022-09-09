using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Components
{
    public class InteractableComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;

        public void Interact()
        {
            _action.Invoke();
        }
    }
}