using UnityEngine;

public class EnableDisable : MonoBehaviour
{
    private Light _spotLight;

    private void Start()
    {
        _spotLight = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) _spotLight.enabled = !_spotLight.enabled;
    }
}