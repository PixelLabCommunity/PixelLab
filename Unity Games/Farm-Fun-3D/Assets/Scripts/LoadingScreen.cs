using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Image _loadingImage;
    [SerializeField] private float _loadingSpeed = 0.15f;
    [SerializeField] private int _sceneId = 2;
    [SerializeField] private float _delaySeconds = 5.0f;

    private void Start()
    {
        StartCoroutine(LoadSceneWithDelayAsync());
    }

    IEnumerator LoadSceneWithDelayAsync()
    {
        yield return new WaitForSeconds(_delaySeconds);

        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneId);

        _loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            _loadingImage.fillAmount = progressValue;

            yield return null;
        }
    }

    private void Update()
    {
        if (_loadingImage.fillAmount != 1f)
        {
            float fillAmountDelta = Time.deltaTime * _loadingSpeed;
            if (_loadingImage.fillAmount + fillAmountDelta > 1f)
                _loadingImage.fillAmount = 1f;
            else
                _loadingImage.fillAmount += fillAmountDelta;
        }
        else
        {
            // Scene loading complete, perform any necessary actions
        }
    }
}
