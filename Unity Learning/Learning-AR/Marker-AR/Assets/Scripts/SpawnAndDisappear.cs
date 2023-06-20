using UnityEngine;

public class SpawnAndDisappear : MonoBehaviour
{
    public GameObject objectPrefab; // Assign the prefab of the GameObject to spawn in the Inspector

    private GameObject spawnedObject;

    private void Start()
    {
        spawnedObject = null;
    }

    public void ToggleSpawnAndDisappear()
    {
        if (spawnedObject == null)
        {
            // Spawn the GameObject when it doesn't exist
            spawnedObject = Instantiate(objectPrefab, transform.position, transform.rotation);
        }
        else
        {
            // Destroy the GameObject when it already exists
            Destroy(spawnedObject);
            spawnedObject = null;
        }
    }
}
