using UnityEngine;

namespace Unity.XRContent.Interaction
{
    /// <summary>
    /// Play a simple sounds using Play one shot with volume, and pitch
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class PlayQuickSound : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The sound that is played")]
        AudioClip m_Sound = null;

        [SerializeField]
        [Tooltip("The volume of the sound")]
        float m_Volume = 1.0f;

        [SerializeField]
        [Tooltip("The range of pitch the sound is played at (-pitch, pitch)")]
        [Range(0, 1)]
        float m_RandomPitchVariance = 0.0f;

        AudioSource m_AudioSource = null;

        float m_DefaultPitch = 1.0f;

        void Awake()
        {
            m_AudioSource = GetComponent<AudioSource>();
        }

        public void Play()
        {
            float randomVariance = Random.Range(-m_RandomPitchVariance, m_RandomPitchVariance);
            randomVariance += m_DefaultPitch;

            m_AudioSource.pitch = randomVariance;
            m_AudioSource.PlayOneShot(m_Sound, m_Volume);
            m_AudioSource.pitch = m_DefaultPitch;
        }

        void OnValidate()
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }
}
