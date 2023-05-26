using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    [SerializeField] private int _buildIndexClose = 2;

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - _buildIndexClose);
        Debug.Log("Returned to Main Menu");
    }

    public void ExitGameButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}