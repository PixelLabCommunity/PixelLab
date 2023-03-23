using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamToOrtho : MonoBehaviour
{

    //public GameObject controllerObject;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    controllerObject.SetActive(true);
    //}





    public void OnTriggerEnter()
    {
        Camera.main.orthographic = true;
    }

    public void OnTriggerExit ()
    {
        Camera.main.orthographic = false;
    }
}
