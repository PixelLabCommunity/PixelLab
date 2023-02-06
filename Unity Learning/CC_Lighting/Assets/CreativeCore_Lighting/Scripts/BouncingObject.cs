using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    public AnimationCurve animCurve;

    private Vector3 startingPos;

    private void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, startingPos.y + animCurve.Evaluate((Time.time % animCurve.length)), transform.position.z);
    }
}
