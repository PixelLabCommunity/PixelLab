using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Cube : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(new Vector3(15, 35, 28) * Time.deltaTime);
        }
    }
}