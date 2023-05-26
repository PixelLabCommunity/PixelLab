using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loadingbar : MonoBehaviour {

    private RectTransform _rectComponent;
    private Image _loadingImage;
    [SerializeField]private float _loadingSpeed = 0.5f;
   

    // Use this for initialization
    void Start () {
        _rectComponent = GetComponent<RectTransform>();
        _loadingImage = _rectComponent.GetComponent<Image>();
        _loadingImage.fillAmount = 0.0f;
    }

    void Update()
    {
        if (_loadingImage.fillAmount != 1f)
        {
            _loadingImage.fillAmount += Time.deltaTime * _loadingSpeed;
            
        }
        else
        {
            _loadingImage.fillAmount = 0.0f;
            
        }
    }
}
