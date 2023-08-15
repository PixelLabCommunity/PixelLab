using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.isKinematic = true;
        m_Rigidbody.useGravity = false;
    }

    public void Detach()
    {
        transform.SetParent(null);
        m_Rigidbody.isKinematic = false;
        var force = gameObject.AddComponent<ConstantForce>();
        
        force.force = Vector3.up;
    }
    
}
