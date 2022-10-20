using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 10.0f;

    private float _horizontalInput;
    private readonly float _xRange = 8.5f;
    public bool _gameOver;

    private void Start()
    {
        _gameOver = false;
    }

    public void Update()
    {
        PlayerBounds();

        _horizontalInput = Input.GetAxis("Horizontal");

        if (_gameOver == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * _turnSpeed *
            _horizontalInput);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private void PlayerBounds()
    {
        if (transform.localPosition.x <= -_xRange)
        {
            transform.localPosition = new Vector3(-_xRange, transform.localPosition.y,
                transform.localPosition.z);
        }
        if (transform.localPosition.x >= _xRange)
        {
            transform.localPosition = new Vector3(_xRange, transform.localPosition.y,
                transform.localPosition.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")
            || collision.gameObject.CompareTag("Obstacle 180"))
        {
            _gameOver = true;
            Debug.Log("Game Over! Press 'ESC' for restart the Game!");
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            Destroy(collision.gameObject);
            Debug.Log("You got a Box!");
        }
    }
}