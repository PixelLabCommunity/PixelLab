using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private int _sceneBuildIndex;

    public void StartGameButton()
    {
        SceneManager.LoadScene(_sceneBuildIndex);
    }
}