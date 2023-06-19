using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Vector3 position = new(4f, 5f, 2f);


    private void Update()
    {
        transform.Rotate(position * (Time.deltaTime * rotationSpeed));
        Debug.Log("GameObject rotating....");
    }
}