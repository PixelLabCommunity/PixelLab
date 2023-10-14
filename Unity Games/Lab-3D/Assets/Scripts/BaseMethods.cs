using UnityEngine;

public class BaseMethods : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Ammo added!");
    }

    private void Start()
    {
        Debug.Log("Shooting.....");
    }

    private void Update()
    {
        Debug.Log("Update Run: " + Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Debug.Log("Fixed Update Run: " + Time.deltaTime);
    }
}