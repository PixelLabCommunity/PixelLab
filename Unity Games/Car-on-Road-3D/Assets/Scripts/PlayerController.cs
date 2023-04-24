using System.IO;
using System.Reflection;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 10.0f;
    [SerializeField] private ParticleSystem _smokeParticle;
    [SerializeField] private ParticleSystem _carDriveParticle;
    [SerializeField] private ParticleSystem _boxParticle;
    [SerializeField] private AudioClip _crashSound;
    [SerializeField] private AudioClip _getBox;
    [SerializeField] private GameObject _thirdPersonView;
    [SerializeField] private GameObject _firstPersonView;
    [SerializeField] private TextMeshProUGUI _speedometrText;
    [SerializeField] private TextMeshProUGUI _boxCountText;
    [SerializeField] private TextMeshProUGUI _gameOverText;

    private AudioSource _playerAudioSource;
    private Rigidbody _playerRigidbody;
    private float _horizontalInput;
    private float _speedX;
    private int _speedRandom;
    private int _speedMin = 70;
    private int _speedMax = 82;
    private float _constKMh = 3.6f;
    private readonly float _xRange = 8.5f;
    public bool _gameOver;
    private int _count;

    private void Start()
    {
        _gameOver = false;

        _gameOverText.gameObject.SetActive(false);

        _playerAudioSource = GetComponent<AudioSource>();
        _playerRigidbody = GetComponent<Rigidbody>();
        _count = 0;
        BoxCount();
    }

    public void FixedUpdate()
    {
        PlayerBounds();
        PlayerControls();
        CameraView();
        CarSpeedText();
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

    private void PlayerControls()
    {
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

    private void CameraView()
    {
        if (Input.GetKey(KeyCode.V))
        {
            _thirdPersonView.gameObject.SetActive(false);
            _firstPersonView.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.C))
        {
            _thirdPersonView.gameObject.SetActive(true);
            _firstPersonView.gameObject.SetActive(false);
        }
    }

    private void CarSpeedText()
    {
        _speedX = Mathf.Round(_playerRigidbody.velocity.magnitude * _constKMh);
        _speedRandom = Random.Range(_speedMin, _speedMax);
        _speedometrText.SetText("Speed: " + _speedRandom + " km/h");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")
            || collision.gameObject.CompareTag("Obstacle 180"))
        {
            _gameOver = true;
            _gameOverText.gameObject.SetActive(true);
            Debug.Log("Game Over! Press 'ESC' for restart the Game!");
            _smokeParticle.Play();
            _playerAudioSource.PlayOneShot(_crashSound);
            _carDriveParticle.Stop();
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            _count++;
            BoxCount();
            Destroy(collision.gameObject);
            Debug.Log("You got a Box!");
            _playerAudioSource.PlayOneShot(_getBox, 0.5f);
            _boxParticle.Play();
        }
    }

    private void BoxCount()
    {
        _boxCountText.SetText("Boxes: " + _count);
    }
}