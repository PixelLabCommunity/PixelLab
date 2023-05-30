using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private int _sceneChangeId;

    public void ExitMenuButton()
    {
        SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex - _sceneChangeId);
    }

    public void ExitGameButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
}