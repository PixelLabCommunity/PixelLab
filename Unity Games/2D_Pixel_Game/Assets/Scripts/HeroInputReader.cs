using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    public void Movement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        _hero.SetDirection(direction);
    }
}