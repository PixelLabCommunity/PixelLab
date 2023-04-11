using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class OnTriggerEvent : MonoBehaviour
{
    [Header("Trigger Enter Event Section")]
    public bool enterIsOneShot;
    public float enterEventCooldown;
    public UnityEvent onTriggerEnterEvent;
    
    [Space]
    [Header("Trigger Exit Event Section")]
    public bool exitIsOneShot;
    public float exitEventCooldown;
    public UnityEvent onTriggerExitEvent;
    
    bool m_EnterHasBeenTriggered;
    float m_EnterTimer;
    
    bool m_ExitHasBeenTriggered;
    float m_ExitTimer;

    void Start()
    {
        m_EnterTimer = enterEventCooldown;
        m_ExitTimer = exitEventCooldown;
    }

    void OnTriggerEnter(Collider other)
    {
        if(enterIsOneShot && m_EnterHasBeenTriggered)
            return;

        if(enterEventCooldown > m_EnterTimer)
            return;

        onTriggerEnterEvent.Invoke();
        m_EnterHasBeenTriggered = true;
        m_EnterTimer = 0f;
    }
    
    void OnTriggerExit(Collider other)
    {
        if(exitIsOneShot && m_ExitHasBeenTriggered)
            return;

        if(exitEventCooldown > m_ExitTimer)
            return;

        onTriggerEnterEvent.Invoke();
        m_ExitHasBeenTriggered = true;
        m_ExitTimer = 0f;
    }

    void Update()
    {
        if (m_EnterHasBeenTriggered)
            m_EnterTimer += Time.deltaTime;
        
        if (m_ExitHasBeenTriggered)
            m_ExitTimer += Time.deltaTime;
    }
}