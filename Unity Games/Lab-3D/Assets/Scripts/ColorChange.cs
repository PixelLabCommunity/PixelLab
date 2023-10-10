using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) GetComponent<Renderer>().material.color = Color.blue;
        if (Input.GetKeyDown(KeyCode.H)) GetComponent<Renderer>().material.color = Color.black;
        if (Input.GetKeyDown(KeyCode.V)) GetComponent<Renderer>().material.color = Color.yellow;
    }
}