using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public List<AudioClip> _grassSteps = new List<AudioClip>();
    public List<AudioClip> _waterSteps = new List<AudioClip>();
    public List<AudioClip> _caveSteps = new List<AudioClip>();

    private enum Surface
    { grass, water, cave };

    private Surface surface;

    private List<AudioClip> currentList;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayStep()
    {
        if (currentList == null)
            return;

        AudioClip clip = currentList[Random.Range(0, currentList.Count)];
        source.PlayOneShot(clip);
    }

    private void SelectStepList()
    {
        switch (surface)
        {
            case Surface.grass:
                currentList = _grassSteps;
                break;

            case Surface.water:
                currentList = _waterSteps;
                break;

            case Surface.cave:
                currentList = _caveSteps;
                break;

            default:
                currentList = null;
                break;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Grass")
        {
            surface = Surface.grass;
        }

        if (hit.transform.tag == "Water")
        {
            surface = Surface.water;
        }

        if (hit.transform.tag == "Cave")
        {
            surface = Surface.cave;
        }

        SelectStepList();
    }
}