using UnityEngine;

public class CloseAppOnThreeTouches : MonoBehaviour
{
    private int _touchCount = 0;
    private readonly float _touchInterval = 1.0f;
    private float _lastTouchTime = 0.0f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                float currentTime = Time.time;
                if (currentTime - _lastTouchTime <= _touchInterval)
                {
                    _touchCount++;
                }
                else
                {
                    _touchCount = 1;
                }

                _lastTouchTime = currentTime;
            }
        }

        if (_touchCount >= 3)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
                activity.Call("finish");
            }
        }
    }
}