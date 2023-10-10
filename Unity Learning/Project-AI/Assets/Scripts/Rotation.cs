using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float speed = 100.0f;
    [SerializeField] private bool rotateLeft = true;
    [SerializeField] private bool rotateUp = true;

    private void Update()
    {
        if (rotateLeft) transform.Rotate(Vector3.left, speed * Time.deltaTime);
        if (rotateUp) transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}