using UnityEngine;

public class GameMusicPlayer : MonoBehaviour
{
    private AudioSource musicAudioSource;

    private void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
        // Load music volume from PlayerPrefs
        float musicVolume = PlayerPrefs.GetFloat(MusicManager.MusicVolumeKey, 1f);

        // Set the music volume
        musicAudioSource.volume = musicVolume;
    }
}
