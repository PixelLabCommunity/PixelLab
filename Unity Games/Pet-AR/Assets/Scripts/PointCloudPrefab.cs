using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PointCloudPrefab : MonoBehaviour
{
    [SerializeField]
    private int _scorePoints;
    public ARPointCloudManager _pointCloudManager;
    public GameObject _pointPrefab;

    private void OnEnable()
    {
        _pointCloudManager.pointCloudsChanged += OnPointCloudsChanged;
    }

    private void OnDisable()
    {
        _pointCloudManager.pointCloudsChanged -= OnPointCloudsChanged;
    }

    private void OnPointCloudsChanged(ARPointCloudChangedEventArgs args)
    {
        ARPointCloud pointCloud = args.updated[0];
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Vector3 point in pointCloud.positions)
        {
            GameObject newPoint = Instantiate(_pointPrefab, point, Quaternion.identity);
            newPoint.transform.parent = transform;
        }
    }
}
