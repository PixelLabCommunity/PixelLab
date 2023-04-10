using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
       // Destroy(other.gameObject);
    }
}
