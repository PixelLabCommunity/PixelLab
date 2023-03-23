using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDisabler : MonoBehaviour
{
    public GameObject player;
    private SkinnedMeshRenderer pRender;

    public void Start()
    {
        pRender = player.GetComponent<SkinnedMeshRenderer>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        pRender.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        pRender.enabled = true;
    }
}
