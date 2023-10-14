using UnityEngine;

public class ActiveDiactive : MonoBehaviour
{
    [SerializeField] private GameObject activeGame;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            activeGame.SetActive(false);
        else if (Input.GetKeyDown(KeyCode.J)) activeGame.SetActive(true);
    }
}