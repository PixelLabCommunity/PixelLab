using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToLoadScene : MonoBehaviour
{
    private readonly int _mainMenu = 0;
    private float _lastTapTime;
    private int _tapCount;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Time.time - _lastTapTime <= 1f)
                _tapCount++;
            else
                _tapCount = 1;

            _lastTapTime = Time.time;


            if (_tapCount == 4) LoadMainMenu();
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(_mainMenu);
    }
}