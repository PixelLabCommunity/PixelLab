using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceParty : MonoBehaviour
{
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("Dance_01");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Dance_02");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Dance_03");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("Dance_04");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            anim.SetTrigger("Dance_05");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            anim.SetTrigger("Dance_06");
        }
    }
}
