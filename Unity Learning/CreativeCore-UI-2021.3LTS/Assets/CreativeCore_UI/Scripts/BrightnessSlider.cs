using UnityEngine;
using UnityEngine.UI;

public class BrightnessSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Light[] _lights;
    [SerializeField] private Renderer[] _renderers;

    private void Update()
    {
        // Update the brightness of all the _lights and _renderers
        foreach (Light light in _lights)
        {
            light.intensity = _slider.value;
        }

        foreach (Renderer renderer in _renderers)
        {
            Material[] materials = renderer.materials;
            foreach (Material material in materials)
            {
                material.SetFloat("_Emission", _slider.value);
            }
        }
    }
}