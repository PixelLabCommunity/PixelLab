using UnityEngine;

public class ParticleScaler : MonoBehaviour
{
    [SerializeField] private float _scaleFactor = 1.5f; 

    private ParticleSystem _particleSystem;
    private ParticleSystem.MainModule _mainModule;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _mainModule = _particleSystem.main;
    }

    private void Update()
    {
        _mainModule.startSize = _scaleFactor * Mathf.Abs(Mathf.Sin(Time.time));
    }
}
