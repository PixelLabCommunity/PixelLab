using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    private List<string> TextToDisplay = new List<string>();

    private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;

    // Start is called before the first frame update
    private void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;

        RotatingSpeed = 1.0f;

        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[CurrentText];

        SparksParticles.Play();
        Test();
    }

    // Update is called once per frame
    private void Update()
    {
        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            }
            Text.text = TextToDisplay[CurrentText];
            TimeToNextText = 0.0f;
        }
    }

    private int dialogue = 3;

    private void Test()
    {
        switch (dialogue)
        {
            case 2:
                print("Goodbye, old friend");
                break;

            case 1:
                print("Hello there");
                break;

            default:
                print("Incorrect dialogue value");
                break;
        }
    }

    private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Test");
        StartCoroutine(MyCoroutine());
    }
}