using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Toggle musicToggle;
    public Slider volumeSlider;
    public AudioSource musicAudioSource;

    private bool isMusicEnabled;
    private float musicVolume;

    private void Awake()
    {
        // Load the saved music enabled state, default to 1 (enabled) if not found
        isMusicEnabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        musicToggle.isOn = isMusicEnabled;

        // Load the saved music volume, default to 0.5f if not found
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        volumeSlider.value = musicVolume;

        // Apply the loaded settings to the music audio source
        musicAudioSource.volume = musicVolume;

        // Update music playback based on the new setting
        if (isMusicEnabled)
        {
            musicAudioSource.Play();
        }
        else
        {
            musicAudioSource.Stop();
        }
    }


    public void ToggleMusic()
    {
        isMusicEnabled = musicToggle.isOn;
        // Save the updated music enabled state
        PlayerPrefs.SetInt("MusicEnabled", isMusicEnabled ? 1 : 0);
        PlayerPrefs.Save();

        // Update music playback based on the new setting
        if (isMusicEnabled)
        {
            musicAudioSource.Play();
        }
        else
        {
            musicAudioSource.Stop();
        }
    }

    public void AdjustVolume()
    {
        musicVolume = volumeSlider.value;
        // Save the updated music volume
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.Save();

        // Update the volume of the music audio source
        musicAudioSource.volume = musicVolume;
    }
}
