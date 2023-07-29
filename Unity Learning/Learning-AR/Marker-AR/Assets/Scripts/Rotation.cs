using UnityEngine;

public class RotateAroundY : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
