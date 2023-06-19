using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    [SerializeField] private GameObject[] placeablePrefabs;
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();

        foreach (GameObject prefab in placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.SetActive(false);
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            SpawnPrefab(trackedImage.referenceImage.name, trackedImage.transform.position);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            SpawnPrefab(trackedImage.referenceImage.name, trackedImage.transform.position);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            DespawnPrefab(trackedImage.referenceImage.name);
        }
    }

    private void SpawnPrefab(string imageName, Vector3 position)
    {
        if (spawnedPrefabs.TryGetValue(imageName, out GameObject prefab))
        {
            prefab.transform.position = position;
            prefab.SetActive(true);

            foreach (GameObject go in spawnedPrefabs.Values)
            {
                if (go != prefab)
                {
                    go.SetActive(false);
                }
            }
        }
    }

    private void DespawnPrefab(string imageName)
    {
        if (spawnedPrefabs.TryGetValue(imageName, out GameObject prefab))
        {
            prefab.SetActive(false);
        }
    }
}
