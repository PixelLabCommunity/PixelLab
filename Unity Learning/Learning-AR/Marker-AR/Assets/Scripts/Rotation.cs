using UnityEngine;

public class RotateAroundY : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust this value to control the rotation speed

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
