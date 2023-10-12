using UnityEngine;

public class Loops : MonoBehaviour
{
    [SerializeField] private int loopNumber = 10;

    private void Start()
    {
        /*LoopNumberResult();*/
        /*WhileNumberResult();*/
        /*DoWhileNumberResult();*/
        ForeachNumberResult();
    }

    private void LoopNumberResult()
    {
        for (var i = 0; i < loopNumber; i++)
        {
            Debug.Log("Result: " + i);
            loopNumber--;
        }
    }

    private void WhileNumberResult()
    {
        while (loopNumber != 0)
        {
            Debug.Log("It's party time!");
            loopNumber--;
        }
    }

    private void DoWhileNumberResult()
    {
        do
        {
            Debug.Log("It's party time!");
            loopNumber--;
        } while (loopNumber != 0);
    }

    private static void ForeachNumberResult()
    {
        var strings = new string[5];
        strings[0] = "Hello, Man!";
        strings[1] = "You are the Best!";
        strings[2] = "You are the hero!";
        strings[3] = "You can do this!";
        strings[4] = "Oh My God!";

        foreach (var item in strings) print(item);
    }
}