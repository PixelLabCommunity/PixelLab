using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    [SerializeField] private MusicManager musicManager;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();

        // Load music volume from PlayerPrefs
        float musicVolume = PlayerPrefs.GetFloat(MusicManager.MusicVolumeKey, 1f);

        // Set the slider value to the loaded music volume
        slider.value = musicVolume;
    }

    public void OnMusicVolumeChanged(float volume)
    {
        // Pass the slider value to the MusicManager to set the music volume
        musicManager.SetMusicVolume(volume);
    }
}
