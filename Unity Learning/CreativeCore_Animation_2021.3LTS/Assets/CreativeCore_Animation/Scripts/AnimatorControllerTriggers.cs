using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerTriggers : MonoBehaviour
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
        /* You can copy the block of code below as many times as you like to have different actions happen for different keys! 
         * To change the keys, delete the A and type in the key you want to replace it with. 
         *
         * If you want to see the full keycode list, you can find it here: https://docs.unity3d.com/ScriptReference/KeyCode.html
         * 
         * Once you've set up your block of code with a key to press, make sure to create a trigger parameter in your Animator
         * Controller, and then type that name into the anim.SetTrigger line where indicated. Be sure to spell it and case it exactly the same!
         * 
         * Don't forget to add this script to your character!
         * 
         */

        //To duplicate this code block, select the code between this comment
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("YOUR_TRIGGER_NAME_HERE_INSIDE_THE_QUOTES");
        }
        //And this comment, then hit CTRL/CMD C to copy, and CTRL/CMD D to paste
        //starting on the line below this one!
        

    }
}
