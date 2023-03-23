using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamView_Switcher : MonoBehaviour
{
    public string AnimTrigger;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger(AnimTrigger);

    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetTrigger("Default");

    }
}
