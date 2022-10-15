using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private MeshRenderer Renderer;
    [SerializeField] private float _spawnX = 3.0f;
    [SerializeField] private float _spawnY = 4.0f;
    [SerializeField] private float _spawnZ = 1.0f;
    [SerializeField] private float _spawnScale = 1.3f;
    [SerializeField] private float _spawnColorR = 0.5f;
    [SerializeField] private float _spawnColorG = 1.0f;
    [SerializeField] private float _spawnColorB = 0.3f;
    [SerializeField] private float _spawnColorA = 0.4f;
    [SerializeField] private float _spawnXAngle = 10.0f;
    [SerializeField] private float _spawnYAngle = 0.0f;
    [SerializeField] private float _spawnZAngle = 0.0f;
    [SerializeField] private float _spawnRotationSpeed = 10.0f;

    private void Start()
    {
        transform.position = new Vector3(_spawnX, _spawnY, _spawnZ);
        transform.localScale = Vector3.one * _spawnScale;

        Material material = Renderer.material;

        material.color = new Color(_spawnColorR, _spawnColorG, _spawnColorB, _spawnColorA);
    }

    private void Update()
    {
        transform.Rotate(_spawnXAngle * Time.deltaTime * _spawnRotationSpeed,
            _spawnYAngle * Time.deltaTime * _spawnRotationSpeed,
            _spawnZAngle * Time.deltaTime * _spawnRotationSpeed);
    }
}