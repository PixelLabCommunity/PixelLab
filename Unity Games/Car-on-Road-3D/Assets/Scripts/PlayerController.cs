using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 20.0f;
    private float _turnSpeed = 45.0f;
    private float _horizontalInput;
    private float _forwardInput;

    // Update is called once per frame

    public void Update()
    {
        // We set input here
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        // We move the vehicle forward based on horizontal input
        transform.Translate(Vector3.forward * Time.deltaTime * _speed * _forwardInput);
        // We turn the vehicle left and right based on vertical input
        transform.Rotate(Vector3.up * Time.deltaTime * _turnSpeed * _horizontalInput);
    }
}