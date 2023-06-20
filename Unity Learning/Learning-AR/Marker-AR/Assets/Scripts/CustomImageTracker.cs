using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CustomImageTracker : MonoBehaviour
{
    public Dictionary<Guid, GameObject> prefabDictionary = new Dictionary<Guid, GameObject>();

    private ARTrackedImageManager trackedImageManager;

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            if (
                prefabDictionary.TryGetValue(
                    trackedImage.referenceImage.guid,
                    out GameObject prefab
                )
            )
            {
                // Instantiate the corresponding prefab and position it appropriately based on the tracked image
                GameObject spawnedObject = Instantiate(
                    prefab,
                    trackedImage.transform.position,
                    trackedImage.transform.rotation
                );
                // Attach the spawned object as a child of the tracked image
                spawnedObject.transform.SetParent(trackedImage.transform);
            }
        }

        // Handle other eventArgs, such as updated and removed images, if needed
    }
}
