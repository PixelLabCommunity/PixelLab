using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Vector3 _position = new Vector3(4f, 5f, 2f);

    private void Update()
    {
        transform.Rotate(_position * Time.deltaTime * _rotationSpeed);
        Debug.Log("GameObject rotating....");
    }
}