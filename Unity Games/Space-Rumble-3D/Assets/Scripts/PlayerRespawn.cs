using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private float _fallPosition = -12.0f;
    private Vector3 _respawnPosition = new Vector3(0f, 12f, 0f);

    private void FixedUpdate()
    {
        if (transform.position.y < _fallPosition)
        {
            transform.position = _respawnPosition;
        }
    }
}