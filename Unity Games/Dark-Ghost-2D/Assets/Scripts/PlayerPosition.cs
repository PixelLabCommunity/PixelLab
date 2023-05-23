using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private float _fallPosition = -12.0f;
    private Vector2 _respawnPosition = new Vector2(-6.90f, -1.60f);

    private void FixedUpdate()
    {
        if (transform.position.y < _fallPosition)
        {
            transform.position = _respawnPosition;
        }
    }
}
