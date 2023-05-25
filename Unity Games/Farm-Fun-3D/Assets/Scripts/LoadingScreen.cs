using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    //[SerializeField] private Image loadingImage;

    private int _sceneDelayId = 2;
    private float _sceneDelaySec = 5.0f;

    private void Start()
    {
        StartCoroutine(AutoLoadSceneAsync(_sceneDelayId, _sceneDelaySec));
    }

    IEnumerator AutoLoadSceneAsync(int sceneId, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        _loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            var _progressBar = Mathf.Clamp01(operation.progress / 0.9f);

            //loadingImage.fillAmount = _progressBar;

            yield return null;
        }
    }


}