using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public List<GameObject> cameraPosition = new List<GameObject>();
    public ThirdPersonController controller;
    
    int activeCam;

    // Start is called before the first frame update
    void Start()
    {
        activeCam = 0;
        setCam(activeCam);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("c"))
        {
            switchCam();
        }
    }

    public void setCam(int idx)
    {
        for (int i = 0; i < cameraPosition.Count; i++)
        {
            if (i == idx)
            {
                cameraPosition[i].SetActive(true);
            }
            else
            {
                cameraPosition[i].SetActive(false);
            }
        }

        if(controller != null) controller.enabled = idx < 2;
    }

    public void switchCam()
    {
        activeCam++;
        if (activeCam > cameraPosition.Count - 1)
            activeCam = 0;
        setCam(activeCam);
    }



}
