using UnityEngine;

public class Lerp : MonoBehaviour
{
    private readonly Vector3 _oneVector = new(2f, 5f, 4f);
    private readonly Vector3 _twoVector = new(5f, 10f, 9f);
    private Vector3 _result;
    private bool _stopName = true;


    private void Update()
    {
        if (_stopName)
        {
            _result = Vector3.Lerp(_oneVector, _twoVector, 0.50f);
            Debug.Log("Result of Lerp is: " + _result);
            _stopName = false;
        }
    }
}