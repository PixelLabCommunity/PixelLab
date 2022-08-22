using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    public GameObject entryContainer;
    public GameObject entryTemplate;
    public Text posText;
    public Text scoreText;
    public Text numberText;
    private void Awake()
    {
    

        float templateHeight = 100f;
        for (int i = 0; i < 15; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate.transform, entryContainer.transform);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
            int rank = i + 1;
            string rankSring;
            switch(rank)
            {
                default: rankSring = rank + "TH";break;
                case 1: rankSring = "1ST";break;
                case 2: rankSring = "2ST"; break;
                case 3: rankSring = "3ST"; break;

            }
            posText.text = rankSring;
            int score = Random.Range(0, 10000);
            scoreText.text = score.ToString();
            string name = "AAA";
            numberText.text = name;
        }
    }
}
