using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 5.0f;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame

    public void Update()
    {
        // We'll move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }
}