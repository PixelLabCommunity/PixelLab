using UnityEngine;

public class CloseApp : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) Application.Quit();
    }
}