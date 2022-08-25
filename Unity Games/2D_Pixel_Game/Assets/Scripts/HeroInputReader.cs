using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    private void Awake()
    {
        Debug.Log(message: "Awake");
    }

    private void OnEnable()
    {
        Debug.Log(message: "OnEnable");
    }

    private void Start()
    {
        Debug.Log(message: "Start");
    }

    private void FixedUpdate()
    {
        Debug.Log(message: "FixedUpdate");
    }

    private void Update()
    {
        Debug.Log(message: "Update");

        var horizontal = Input.GetAxis("Horizontal");
        _hero.SetDirection(horizontal);

        //if (Input.GetKey(KeyCode.A))
        //{
        //    _hero.SetDirection(-1);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    _hero.SetDirection(1);
        //}
        //else
        //{
        //    _hero.SetDirection(0);
        //}
    }

    private void LateUpdate()
    {
        Debug.Log(message: "LateUpdate");
    }

    private void OnDisable()
    {
        Debug.Log(message: "OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log(message: "OnDestroy");
    }
}