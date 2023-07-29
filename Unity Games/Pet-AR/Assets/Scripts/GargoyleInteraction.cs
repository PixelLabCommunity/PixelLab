using UnityEngine;
using TMPro;

public class GargoyleInteraction : MonoBehaviour
{
    [SerializeField] private string[] randomTexts = { "Don't touch it!", "Be careful!", "I told you Don't touch it!" };
    [SerializeField] private Canvas canvasReference;
    [SerializeField] private TMP_FontAsset fontAsset;
    [SerializeField] private float messageDuration = 5.0f;

    private GameObject _currentTextObject;
    private TextMeshProUGUI _currentTextComponent;
    private float _despawnTime;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                SpawnRandomText();
            }
        }

        if (_currentTextObject != null && Time.time >= _despawnTime)
        {
            Destroy(_currentTextObject);
        }
    }

    private void SpawnRandomText()
    {
        if (_currentTextObject != null)
        {
            Destroy(_currentTextObject);
        }

        int randomIndex = Random.Range(0, randomTexts.Length);

        GameObject textObject = new GameObject("RandomText");
        textObject.transform.position = transform.position + Vector3.up * 2.0f;

        TextMeshProUGUI textComponent = textObject.AddComponent<TextMeshProUGUI>();
        textComponent.text = randomTexts[randomIndex];
        textComponent.font = fontAsset;
        textComponent.fontSize = 75;
        textComponent.color = Color.white;
        textComponent.alignment = TextAlignmentOptions.Center;

        textObject.transform.SetParent(canvasReference.transform, false);

        textObject.SetActive(true);

        _currentTextObject = textObject;
        _currentTextComponent = textComponent;
        _despawnTime = Time.time + messageDuration;
    }
}