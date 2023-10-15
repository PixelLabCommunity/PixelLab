using UnityEngine;

public class TransformRotate : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float rotateSpeed = 50.0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));
        if (Input.GetKey(KeyCode.DownArrow)) transform.Translate(Vector3.down * (moveSpeed * Time.deltaTime));
        if (Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow)) transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
    }
}