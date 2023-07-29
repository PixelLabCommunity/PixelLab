using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 position = new(45f, 55f, 20f);

    private void Update()
    {
        transform.Rotate(position * (Time.deltaTime * speed));
    }
}