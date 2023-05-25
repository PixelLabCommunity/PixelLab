using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    private readonly int _buildIndexClose = 2;

    public void ExitGameTitle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - _buildIndexClose);
        Debug.Log("Game Closed");
    }

}