using UnityEngine;

public class SoundCoin : MonoBehaviour
{
    [SerializeField] private AudioClip _coinSound;

    private AudioSource _playerAudioSource;

    private float _soundVolume = 0.5f;

    private void Start()
    {
        _playerAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 

        if (other.CompareTag("Coin") || other.CompareTag("ExtraCoin"))
        {
            _playerAudioSource.PlayOneShot(_coinSound, _soundVolume);
        }
    }
}
