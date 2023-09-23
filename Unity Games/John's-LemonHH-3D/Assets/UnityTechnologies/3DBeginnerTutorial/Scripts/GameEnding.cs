using UnityEngine;
using UnityEngine.SceneManagement;

public partial class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    private bool m_HasAudioPlayed;

    private bool m_IsPlayerAtExit;
    private bool m_IsPlayerCaught;
    private float m_Timer;

    private void Update()
    {
        if (m_IsPlayerAtExit)
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        else if (m_IsPlayerCaught) EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player) m_IsPlayerAtExit = true;
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    private void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
                SceneManager.LoadScene(0);
            else
                Application.Quit();
        }
    }
}