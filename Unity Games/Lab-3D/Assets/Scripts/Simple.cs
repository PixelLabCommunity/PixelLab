using UnityEngine;

public class Simple : MonoBehaviour
{
    private int _myInt = 5;

    private void Start()
    {
        _myInt = MultiplyNumber(_myInt);
        Debug.Log(_myInt);
    }

    private int MultiplyNumber(int number)
    {
        int _result;
        _result = number * 2;
        return _result;
    }
}