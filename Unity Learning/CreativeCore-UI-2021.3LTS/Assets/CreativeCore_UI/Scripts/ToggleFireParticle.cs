using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class ToggleFireParticle : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Space;

    private ParticleSystem fireParticle;
    public ParticleSystem igniteParticle;
    public ParticleSystem extinguishParticle;
    public GameObject pointLight;

    private void Start()
    {
        fireParticle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if(fireParticle.isPlaying)
            {
                fireParticle.Stop();
                pointLight.SetActive(false);
                if (extinguishParticle != null)
                    extinguishParticle.Play();
            } else
            {
                fireParticle.Play();
                pointLight.SetActive(true);
                if (igniteParticle != null)
                    igniteParticle.Play();
            }
        }
    }
}
