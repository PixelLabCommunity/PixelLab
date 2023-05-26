using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMusic : MonoBehaviour
{
    [SerializeField] private float _defaultMusicVolume = 1f;
    private static MainMusic _mainMusic;

    private void Awake()
    {
        if (_mainMusic == null)
        {
            _mainMusic = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(_mainMusic.gameObject);
            _mainMusic = this;
            DontDestroyOnLoad(gameObject);
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
            ResetSettings();
            Destroy(gameObject);
        }
    }

    private void ResetSettings()
    {
        // Reset the music volume settings
        PlayerPrefs.SetFloat("MusicVolume", _defaultMusicVolume);
        PlayerPrefs.Save();
        // Reset other scene settings and states
        // Add your code here to reset any other relevant settings or states
    }
}
