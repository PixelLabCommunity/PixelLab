using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 10.0f;

    private float _horizontalInput;
    private readonly float _xRange = 8.5f;

    public void Update()
    {
        PlayerBounds();

        _horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * _turnSpeed * _horizontalInput);
    }

    private void PlayerBounds()
    {
        if (transform.localPosition.x <= -_xRange)
        {
            transform.localPosition = new Vector3(-_xRange, transform.localPosition.y,
                transform.localPosition.z);
        }
        if (transform.localPosition.x >= _xRange)
        {
            transform.localPosition = new Vector3(_xRange, transform.localPosition.y,
                transform.localPosition.z);
        }
    }
}