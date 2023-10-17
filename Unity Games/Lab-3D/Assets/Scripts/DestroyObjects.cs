using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    [SerializeField] private GameObject destroyObject;
    [SerializeField] private float delayedDestroy = 5.0f;

    private void Update()
    {
        // DestroyObject();
        // DestroyObjectDelayed();
        DestroyComponent();
    }

    private void DestroyObject()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Destroy(destroyObject);
    }

    private void DestroyObjectDelayed()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Destroy(destroyObject, delayedDestroy);
    }

    private void DestroyComponent()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if (Input.GetKeyDown(KeyCode.Space))
                Destroy(destroyObject.GetComponent<MeshRenderer>());
    }
}