using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _position;



    private void Update()
    {
        Move(_position);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _position = context.ReadValue<Vector2>();
        
    }

    
    private void Move(Vector2 direction)
    {
        float _upSpeed = _moveSpeed * Time.deltaTime;
        Vector3 _movement = new Vector3(direction.x, 0, direction.y);
        transform.position += _movement * _upSpeed;

    }
}