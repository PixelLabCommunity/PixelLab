using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;     

[RequireComponent(typeof(VisualEffect))]

public class ToggleFireVFXGraph : MonoBehaviour
{
    
    public KeyCode toggleKey = KeyCode.Space;
    private bool isPlaying = true;

    private VisualEffect fireVFX;
    public VisualEffect igniteVFX;
    public VisualEffect extinguishVFX;

    private void Start()
    {
        fireVFX = GetComponent<VisualEffect>();
        if (igniteVFX != null)
            igniteVFX.Stop();
        if (extinguishVFX != null)
            extinguishVFX.Stop();
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if(isPlaying)
            {
                isPlaying = !isPlaying;
                fireVFX.Stop();
                if (extinguishVFX != null)
                    extinguishVFX.Play();
            } else
            {
                isPlaying = !isPlaying;
                fireVFX.Play();
                if (igniteVFX != null)
                    igniteVFX.Play();
            }
        }
    }
}
