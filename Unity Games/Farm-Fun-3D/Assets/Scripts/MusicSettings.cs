using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSettings : MonoBehaviour
{
    public AudioSource _audioSource;

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("volume", _audioSource.volume);
    }

    public void LoadSettinds()
    {
        var volume = PlayerPrefs.GetFloat("volume");
        _audioSource.volume = volume;

    }
}
