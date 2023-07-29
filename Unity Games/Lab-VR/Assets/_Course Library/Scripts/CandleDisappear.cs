using UnityEngine;

public class CandleDisappear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag($"Candle"))
        {
            Destroy(other.gameObject);
        }
    }
}
