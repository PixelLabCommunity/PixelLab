using UnityEngine;

public class Simple : MonoBehaviour
{
    private int _myInt = 5;
    private int _myIntSum = 100;

    private void Start()
    {
        _myInt = MultiplyNumber(_myInt);
        _myIntSum = SummNumber(_myIntSum);
        Debug.Log("Multiply number is: " + _myInt);
        Debug.Log("Sum number is: " + _myIntSum);
    }

    private void Update()
    {
        ChangeColor();
    }

    private int MultiplyNumber(int number)
    {
        int result;
        result = number * 2;
        return result;
    }

    private int SummNumber(int number)
    {
        int result;
        result = number + 100;
        return result;
    }

    private void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.M)) GetComponent<Renderer>().material.color = Color.blue;
    }
}