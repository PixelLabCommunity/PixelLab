using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGameButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
}