using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField] private GameObject _dogPrefab;

    private void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_dogPrefab, transform.position, _dogPrefab.transform.rotation);
        }
    }
}