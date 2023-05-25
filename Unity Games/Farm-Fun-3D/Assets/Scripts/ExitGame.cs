using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    private int _buildIndexClose = 1;

    public void ExitGameTitle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - _buildIndexClose);
        Debug.Log("Game Closed");
    }
}