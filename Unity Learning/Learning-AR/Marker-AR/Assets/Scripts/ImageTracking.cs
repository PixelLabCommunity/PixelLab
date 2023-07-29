using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracking : MonoBehaviour
{
    [SerializeField] private GameObject[] placeablePrefabs;
    private readonly Dictionary<string, GameObject> _spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager _trackedImageManager;

    private void Awake()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();

        foreach (GameObject prefab in placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.SetActive(false);
            _spawnedPrefabs.Add(prefab.name, newPrefab);
        }
    }

    private void OnEnable()
    {
        _trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        _trackedImageManager.trackedImagesChanged -= ImageChanged;
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
        if (!_spawnedPrefabs.TryGetValue(imageName, out GameObject prefab)) return;
        prefab.transform.position = position;
        prefab.SetActive(true);

        foreach (var go in _spawnedPrefabs.Values.Where(go => go != prefab))
        {
            go.SetActive(false);
        }
    }

    private void DespawnPrefab(string imageName)
    {
        if (_spawnedPrefabs.TryGetValue(imageName, out GameObject prefab))
        {
            prefab.SetActive(false);
        }
    }
}
