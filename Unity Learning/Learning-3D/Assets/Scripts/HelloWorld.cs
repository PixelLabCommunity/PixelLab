using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private string _myMessage;

    private void Start()
    {
        Debug.Log(_myMessage);
    }
    private void Update()
    {
        Debug.Log(_myMessage);
    }
}
