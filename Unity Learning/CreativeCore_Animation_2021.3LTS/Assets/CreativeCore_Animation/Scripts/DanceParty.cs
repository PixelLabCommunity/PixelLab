using UnityEngine;

public class DanceParty : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _anim.SetTrigger("Dance_01");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _anim.SetTrigger("Dance_02");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _anim.SetTrigger("Dance_03");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _anim.SetTrigger("Dance_04");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            _anim.SetTrigger("Dance_05");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            _anim.SetTrigger("Dance_06");
        }
    }
}