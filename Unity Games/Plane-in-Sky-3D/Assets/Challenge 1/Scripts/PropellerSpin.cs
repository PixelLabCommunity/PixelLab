using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        // Propeller spin here
        transform.Rotate(new Vector3(0, 0, 2000) * Time.deltaTime);
    }
}