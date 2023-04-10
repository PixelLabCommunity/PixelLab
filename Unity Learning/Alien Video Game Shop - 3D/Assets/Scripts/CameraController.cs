using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public void MoveToNewPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}
