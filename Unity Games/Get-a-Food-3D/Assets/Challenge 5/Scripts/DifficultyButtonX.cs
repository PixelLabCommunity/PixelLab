using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX : MonoBehaviour
{
    private Button _button;
    private GameManagerX _gameManagerX;
    public int _difficulty;

    // Start is called before the first frame update
    private void Start()
    {
        _gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    /* When a _button is clicked, call the StartGame() method
     * and pass it the _difficulty value (1, 2, 3) from the _button
    */

    private void SetDifficulty()
    {
        Debug.Log(_button.gameObject.name + " was clicked");
        _gameManagerX.StartGame(_difficulty);
    }
}