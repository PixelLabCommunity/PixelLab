using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PointCloudPrefab : MonoBehaviour
{
    public ARPointCloudManager _pointCloudManager;
    public GameObject _pointPrefab;

    void OnEnable()
    {
        _pointCloudManager.pointCloudsChanged += OnPointCloudsChanged;
    }

    void OnDisable()
    {
        _pointCloudManager.pointCloudsChanged -= OnPointCloudsChanged;
    }

    void OnPointCloudsChanged(ARPointCloudChangedEventArgs args)
    {
        ARPointCloud pointCloud = args.updated[0];

        // Clear any previously created points
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate a prefab for each point in the point cloud
        foreach (Vector3 point in pointCloud.positions)
        {
            GameObject newPoint = Instantiate(_pointPrefab, point, Quaternion.identity);
            newPoint.transform.parent = transform;
        }
    }
}
