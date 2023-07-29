using UnityEngine;

public class FollowMarker : MonoBehaviour
{
    public GameObject arCamera; // Assign the reference to your AR camera GameObject in the Inspector
    public GameObject spawnedObject; // Assign the spawned GameObject to this variable in the Inspector

    private void LateUpdate()
    {
        if (arCamera != null)
        {
            // Position the container GameObject at the same position as the AR camera
            transform.position = arCamera.transform.position;

            // Rotate the container GameObject to match the rotation of the AR camera
            transform.rotation = arCamera.transform.rotation;
        }
    }
}
