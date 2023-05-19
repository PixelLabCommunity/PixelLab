using System.Collections;
using TMPro;
using UnityEngine;

public class PointText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _pointText;
    [SerializeField] private int _coinPoint;
    [SerializeField] private int _coinExtraPoint;

    private float _timerRespawnText = 2.0f;

    private void Start()
    {
        _pointText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin") || other.CompareTag("ExtraCoin"))
        {
            int coinPoint = (other.CompareTag("Coin")) ? _coinPoint : _coinExtraPoint;

            _pointText.gameObject.SetActive(true);
            _pointText.text = "+ " + coinPoint;

            StartCoroutine(HideSpawnText());
        }
    }

    private IEnumerator HideSpawnText()
    {
        yield return new WaitForSeconds(_timerRespawnText);
        _pointText.gameObject.SetActive(false);
    }
}