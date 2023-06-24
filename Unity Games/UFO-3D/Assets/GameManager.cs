using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject sheepGroup;
    [SerializeField] private int sheepCount = 7;


    private void Start()
    {
        SpawnSheep();
    }

    private void SpawnSheep()
    {
        foreach (Transform sheepTransform in sheepGroup.transform) sheepTransform.gameObject.SetActive(false);

        for (var i = 0; i < sheepCount; i++)
        {
            var randomIndex = Random.Range(1, sheepGroup.transform.childCount);
            var sheepTransform = sheepGroup.transform.GetChild(randomIndex);
            sheepTransform.gameObject.SetActive(true);
        }
    }
}