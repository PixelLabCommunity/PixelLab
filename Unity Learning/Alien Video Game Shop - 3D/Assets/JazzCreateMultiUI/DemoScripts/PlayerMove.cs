using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))] // makes sure player has a rigidbody attached to contol movement.
public class PlayerMove : MonoBehaviour
{
    public float shipSpeed = 5f;

    private float minX, maxX, minY, maxY;
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        minX = bottomCorner.x + 1f;
        maxX = topCorner.x - 1f;
        minY = bottomCorner.y + 1f;
        maxY = topCorner.y - 1f;
    }
    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.x < minX) pos.x = minX;
        if (pos.x > maxX) pos.x = maxX;
        if (pos.y < minY) pos.y = minY;
        if (pos.y > maxY) pos.y = maxY;
        transform.position = pos;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2D.velocity = movement * shipSpeed;
    }

}
