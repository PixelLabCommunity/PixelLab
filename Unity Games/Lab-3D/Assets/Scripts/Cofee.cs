using UnityEngine;

public class Cofee : MonoBehaviour
{
    private readonly float _maxTempreture = 100.0f;
    private readonly float _minTempreture = 40.0f;
    private float _coffeeTempreture;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) TempretureTest();
        _coffeeTempreture = Random.Range(0, 150);
    }

    private void TempretureTest()
    {
        if (_coffeeTempreture > _maxTempreture) print("Coffee too hot! Ou ou ou......");
        else if (_coffeeTempreture < _minTempreture) print("Coffee too COLD!!! Yaya!");
        else
            print("Coffee OK! Nice delitions....");
    }
}