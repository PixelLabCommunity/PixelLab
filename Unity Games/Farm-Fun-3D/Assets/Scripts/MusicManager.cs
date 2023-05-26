using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static readonly string MusicVolumeKey = "MusicVolume";

    [SerializeField] private AudioSource musicAudioSource;

    private void Start()
    {
        // Load music volume from PlayerPrefs
        float musicVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);

        // Set the music volume
        musicAudioSource.volume = musicVolume;
    }

    public void SetMusicVolume(float volume)
    {
        // Update the music volume in PlayerPrefs
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();

        // Set the music volume immediately
        musicAudioSource.volume = volume;
    }
}
