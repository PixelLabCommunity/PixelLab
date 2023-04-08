using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    [SerializeField] private GameObject _objectToEnableDisable;
    [SerializeField] private float _enableTime = 2f;
    [SerializeField] private float _disableTime = 5f;

    private float _timer;
    private float _startTimer = 0f;
    private bool _isEnabled;

    private void Start()
    {
        _timer = _enableTime;
        _isEnabled = true;
        _objectToEnableDisable.SetActive(_isEnabled);
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= _startTimer && _isEnabled)
        {
            _isEnabled = false;
            _objectToEnableDisable.SetActive(_isEnabled);
            _timer = _disableTime;
        }

        if (_timer <= _startTimer && !_isEnabled)
        {
            _isEnabled = true;
            _objectToEnableDisable.SetActive(_isEnabled);
            _timer = _enableTime;
        }
    }
}