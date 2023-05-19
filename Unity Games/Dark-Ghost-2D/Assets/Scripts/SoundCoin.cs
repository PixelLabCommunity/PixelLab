using UnityEngine;

public class SoundCoin : MonoBehaviour
{
    [SerializeField] private AudioClip _coinSound;

    private AudioSource _playerAudioSource;

    private void Start()
    {
        _playerAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 

        if (other.CompareTag("Coin"))
        {
            _playerAudioSource.PlayOneShot(_coinSound, 0.5f);
        }
    }
}
