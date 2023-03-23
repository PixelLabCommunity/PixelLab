using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    //public Camera MainCamera;
    public List<GameObject> cameraPosition = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < cameraPosition.Count; i++)
        {
            cameraPosition[i].SetActive(false);
            
        }
        cameraPosition[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchCamera()
    {

        for (int i = 0; i < cameraPosition.Count; i++)
        {
            if (cameraPosition[i].activeSelf == true)
            {
                cameraPosition[i].SetActive(false);
                
            }
            cameraPosition[i + 1].SetActive(true);
        }

    }
}
