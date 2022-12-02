using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject _player;
    [SerializeField] private Vector3 _offset = new Vector3(0.0f, 5.0f, -8.0f);

    private void LateUpdate()
    {
        // Offset the camera behind the player's position
        transform.position = _player.transform.position + _offset;
    }
}