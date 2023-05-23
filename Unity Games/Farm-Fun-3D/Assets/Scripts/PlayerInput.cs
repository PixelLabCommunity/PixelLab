using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefabPizza;
    [SerializeField] private FixedJoystick _joystick;

    private float _horizontalInput;
    private readonly float _xRange = 16.5f;

    private void Update()
    {
        PlayerBounds();

        PlayerMovement();
    }

    private void PlayerMovement()
    {
        // Keyboard input
        float keyboardInput = Input.GetAxis("Horizontal");

        // Joystick input
        float joystickInput = _joystick.Horizontal;

        // Calculate the total horizontal input
        float horizontalInput = keyboardInput + joystickInput;

        // Apply the movement
        transform.Translate(horizontalInput * _speed * Time.deltaTime * Vector3.right);
    }

    public void PlayerShoot()
    {
        Instantiate(_prefabPizza, transform.position, _prefabPizza.transform.rotation);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_prefabPizza, transform.position, _prefabPizza.transform.rotation);
        }
    }

    private void PlayerBounds()
    {
        // Keep Player in bounds
        if (transform.localPosition.x <= -_xRange)
        {
            transform.localPosition = new Vector3(-_xRange, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x >= _xRange)
        {
            transform.localPosition = new Vector3(_xRange, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
