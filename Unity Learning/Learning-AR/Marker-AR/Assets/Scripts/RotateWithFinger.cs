using UnityEngine;

public class RotateWithFinger : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _isRotating = false;
    private readonly float _rotationSpeed = 5f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _initialPosition = touch.position;
                    _isRotating = true;
                    break;

                case TouchPhase.Moved:
                    if (_isRotating)
                    {
                        float deltaX = touch.deltaPosition.x * _rotationSpeed * Time.deltaTime;
                        transform.Rotate(0f, deltaX, 0f, Space.World);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    _isRotating = false;
                    break;
            }
        }
    }
}