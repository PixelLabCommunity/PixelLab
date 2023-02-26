using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    public AnimationCurve _animCurve;

    private Vector3 _startingPos;

    private void Start()
    {
        _startingPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, _startingPos.y + _animCurve.Evaluate((Time.time % _animCurve.length)), transform.position.z);
    }
}