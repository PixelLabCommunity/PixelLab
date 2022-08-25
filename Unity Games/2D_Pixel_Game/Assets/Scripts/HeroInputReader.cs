using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    public void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        var directionX = context.ReadValue<float>();
        _hero.SetDirectionX(directionX);
    }

    public void OnVerticalMovement(InputAction.CallbackContext context)
    {
        var directionY = context.ReadValue<float>();
        _hero.SetDirectionY(directionY);
    }
}