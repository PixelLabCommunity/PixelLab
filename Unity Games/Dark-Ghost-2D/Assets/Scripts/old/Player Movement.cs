using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private Vector2 _movement;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        //RotateTowardDirection();
        FaceMouse();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * _speed * Time.deltaTime);
    }

    private void RotateTowardDirection()
    {
        if (_movement != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.back, _movement);
        }
    }

    private void FaceMouse()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 screenpoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 offset = new Vector2(mouse.x - screenpoint.x, mouse.y - screenpoint.y);
        float angle = Mathf.Atan2(offset.x, offset.y) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}