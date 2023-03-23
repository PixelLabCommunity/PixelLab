using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShots : MonoBehaviour
{
    public Camera wideCam;
    public Camera closeCam;
    public Camera birdCam;
    public Camera wormCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("1"))
        {
            WideCam();
        }

        if (Input.GetKeyUp("2"))
        {
            CloseCam();
        }
        if (Input.GetKeyUp("3"))
        {
            BirdCam();
        }
        if (Input.GetKeyUp("4"))
        {
            WormCam();
        }
    }

    public void CloseCam()
    {
        closeCam.enabled = true;
        wideCam.enabled = false;
        birdCam.enabled = false;
        wormCam.enabled = false;
    }

    public void WideCam()
    {
        wideCam.enabled = true;
        closeCam.enabled = false;
        birdCam.enabled = false;
        wormCam.enabled = false;
    }

    public void WormCam()
    {
        wideCam.enabled = false;
        closeCam.enabled = false;
        birdCam.enabled = false;
        wormCam.enabled = true;
    }

    public void BirdCam()
    {
        wideCam.enabled = false;
        closeCam.enabled = false;
        birdCam.enabled = true;
        wormCam.enabled = false;
    }

}
