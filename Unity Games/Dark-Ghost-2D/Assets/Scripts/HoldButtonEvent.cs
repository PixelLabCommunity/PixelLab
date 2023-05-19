using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Scripts
{
    public class HoldButtonEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public UnityEvent onHoldEvent;
        public float holdDuration = 1f;

        private bool isPointerDown = false;
        private float holdTimer = 0f;

        private void Update()
        {
            if (isPointerDown)
            {
                holdTimer += Time.deltaTime;

                if (holdTimer >= holdDuration)
                {
                    onHoldEvent.Invoke();
                    ResetHold();
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPointerDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ResetHold();
        }

        private void ResetHold()
        {
            isPointerDown = false;
            holdTimer = 0f;
        }
    }
}