using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMusic : MonoBehaviour
{
    private static MainMusic _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            DestroyDuplicates();
        }
    }

    private void DestroyDuplicates()
    {
        MainMusic[] duplicates = FindObjectsOfType<MainMusic>();

        foreach (MainMusic duplicate in duplicates)
        {
            if (duplicate != _instance)
            {
                Destroy(duplicate.gameObject);
            }
        }
    }
}