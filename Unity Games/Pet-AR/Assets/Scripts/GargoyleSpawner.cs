using UnityEngine;

public class GargoyleSpawner : MonoBehaviour
{
    public GameObject gargoylePrefab;
    public GameObject uiPanel;

    private bool _isGargoyleSpawned;

    private void Update()
    {
        if (_isGargoyleSpawned)
            return;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SpawnGargoyle();
            uiPanel.SetActive(false); 
        }
    }

    private void SpawnGargoyle()
    {
        var transform1 = transform;
        Instantiate(gargoylePrefab, transform1.position, transform1.rotation);
        _isGargoyleSpawned = true;
    }
}