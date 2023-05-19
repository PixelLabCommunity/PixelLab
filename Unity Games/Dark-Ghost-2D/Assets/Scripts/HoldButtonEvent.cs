using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Scripts
{
    public class HoldButtonEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public UnityEvent _onHoldEvent;
        public float _holdDuration = 1f;

        private bool _isPointerDown = false;
        private float _holdTimer = 0f;

        private void Update()
        {
            if (_isPointerDown)
            {
                _holdTimer += Time.deltaTime;

                if (_holdTimer >= _holdDuration)
                {
                    _onHoldEvent.Invoke();
                    ResetHold();
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isPointerDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ResetHold();
        }

        private void ResetHold()
        {
            _isPointerDown = false;
            _holdTimer = 0f;
        }
    }
}