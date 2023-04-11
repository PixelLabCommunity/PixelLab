using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InteractHandler : MonoBehaviour
{
    public GameObject UIPrefab; 

    [FormerlySerializedAs("InteractableIcone")]
    public Sprite InteractablePointer;
    public Sprite NormalPointer;
    
    Image m_PointerImage;
    private Vector3 m_OriginalPointerSize;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        Instantiate(UIPrefab);

        var mainCam = Camera.main;
        var cinemachineBrain = mainCam.GetComponent<CinemachineBrain>();
        if (cinemachineBrain == null)
            mainCam.gameObject.AddComponent<CinemachineBrain>();

        var centerPoint = GameObject.Find("CenterPoint");
        if (centerPoint != null)
        {
            m_PointerImage = centerPoint.GetComponent<Image>();
            m_OriginalPointerSize = centerPoint.transform.localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        OnInteract[] targets = null;
        var ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        RaycastHit hit;

        bool displayInteractable = false;
        if (Physics.Raycast(ray, out hit, 2.0f))
        {
            var interacts = hit.collider.gameObject.GetComponentsInChildren<OnInteract>();

            if (interacts.Length > 0)
            {
                displayInteractable = true;
                targets = interacts;
                m_PointerImage.color = Color.white;
                
                foreach (var target in targets)
                {
                    if (!target.isActiveAndEnabled)
                    {
                        m_PointerImage.color = Color.grey;
                        break;
                    }
                }
            }
        }
        
        if (targets != null && 
            (Mouse.current.leftButton.wasPressedThisFrame || Keyboard.current.eKey.wasPressedThisFrame ))
        {
            foreach (var target in targets)
            {
                if(target.isActiveAndEnabled)
                    target.Interact();
            }
        }

        if (displayInteractable)
        {
            m_PointerImage.sprite = InteractablePointer;
            m_PointerImage.transform.localScale = m_OriginalPointerSize * 2.0f;
        }
        else
        {
            m_PointerImage.sprite = NormalPointer;
            m_PointerImage.color = Color.white;
            m_PointerImage.transform.localScale = m_OriginalPointerSize;
        }
    }
}
