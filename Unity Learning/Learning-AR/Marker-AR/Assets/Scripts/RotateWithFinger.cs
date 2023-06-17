using UnityEngine;

public class RotateWithFinger : MonoBehaviour
{
    [SerializeField]
    private float autoRotationSpeed = 5f;

    [SerializeField]
    public float manualRotationSpeed = 10f;

    private bool isAutoRotating = true;
    private bool isRotatingManually = false;
    private float manualRotationDirection = 0f;

    private void Update()
    {
        // Auto rotation
        if (isAutoRotating && !isRotatingManually)
        {
            transform.Rotate(0f, autoRotationSpeed * Time.deltaTime, 0f, Space.World);
        }

        // Manual rotation
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isRotatingManually = true;
                    break;

                case TouchPhase.Moved:
                    if (isRotatingManually)
                    {
                        float deltaX = touch.deltaPosition.x;
                        manualRotationDirection = Mathf.Sign(deltaX);
                        isAutoRotating = false;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isRotatingManually = false;
                    isAutoRotating = true;
                    break;
            }
        }

        if (isRotatingManually)
        {
            float rotationAmount = manualRotationDirection * manualRotationSpeed * Time.deltaTime;
            transform.Rotate(0f, rotationAmount, 0f, Space.World);
        }
    }
}
