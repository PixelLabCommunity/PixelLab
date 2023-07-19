using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerWithSpatialAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool playOnAwake;

    private VideoPlayer _videoPlayer;

    private void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();

        if (audioSource == null)
        {
            Debug.LogError(
                "Please assign an AudioSource component to the VideoPlayerWithSpatialAudio script in the Inspector.");
            return;
        }

        _videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        _videoPlayer.SetTargetAudioSource(0, audioSource);

        if (playOnAwake) Play();
    }

    public void Play()
    {
        _videoPlayer.Play();
    }

    public void Pause()
    {
        _videoPlayer.Pause();
    }

    public void Stop()
    {
        _videoPlayer.Stop();
    }
}