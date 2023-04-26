using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int _sceneNumber = 1;

    private void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _sceneNumber);
    }

    private void ExitGame()
    {
        Debug.Log("Game was closed");
        Application.Quit();
    }
}