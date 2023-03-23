using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Camera MainCamera;
    public List<GameObject> cameraPosition = new List<GameObject>();
    public GameObject targetPosition;
    public int speed = 1;
    public bool camera_move_enabled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (camera_move_enabled)
        {
            MainCamera.transform.position = Vector3.Lerp(transform.position, targetPosition.transform.position, speed * Time.deltaTime);
            MainCamera.transform.rotation = Quaternion.Lerp(transform.rotation, targetPosition.transform.rotation, speed * Time.deltaTime);
            camera_move_enabled = false;
        }
    }

    public void NextCam()
   {
        camera_move_enabled = true;
   }
}
