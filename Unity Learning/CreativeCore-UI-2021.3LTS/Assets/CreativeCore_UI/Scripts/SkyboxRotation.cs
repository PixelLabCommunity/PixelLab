using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    [SerializeField] private Material _skyboxMaterial;
    [SerializeField] private float _speed = 2f;

    private float _elapsedTime = 0f;
    private float _timeScale = 2.5f;

    private static readonly int Rotation = Shader.PropertyToID("_Rotation");
    private static readonly int Exposure = Shader.PropertyToID("_Exposure");

    // Update is called once per frame
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        _skyboxMaterial.SetFloat(Rotation, _elapsedTime * _timeScale);
        _skyboxMaterial.SetFloat(Exposure, Mathf.Clamp(Mathf.Sin(_elapsedTime), 015f, 1f));
    }
}