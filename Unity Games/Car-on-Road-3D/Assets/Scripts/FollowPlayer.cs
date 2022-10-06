using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject _player;
    private Vector3 _offset = new Vector3(0f, 5f, -7f);

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        // Offset the camera behind the player's position
        transform.position = _player.transform.position + _offset;
    }
}