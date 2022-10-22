using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10.0f;
    [SerializeField] private float _gravityValue = 18.0f;
    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private ParticleSystem _dirtParticle;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _smashSound;

    private Rigidbody _playerRb;
    private Animator _playerAnimation;
    private AudioSource _playerAudioSource;
    private bool _isOnGround = true;
    public bool _gameOver;

    private void Awake()
    {
        Debug.ClearDeveloperConsole();
    }

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0.0f, -_gravityValue, 0.0f);
        _playerAnimation = GetComponent<Animator>();
        _playerAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PlayerJump();
    }

    private void LateUpdate()
    {
        RestartLevel();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            _dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            Debug.Log("Game Over! Press 'ESC' for restart the Game!");
            _playerAnimation.SetBool("Death_b", true);
            _playerAnimation.SetInteger("DeathType_int", 1);
            _explosionParticle.Play();
            _dirtParticle.Stop();
            _playerAudioSource.PlayOneShot(_smashSound);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !_gameOver)
        {
            _playerRb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _playerAnimation.SetTrigger("Jump_trig");
            _dirtParticle.Stop();
            _playerAudioSource.PlayOneShot(_jumpSound);
        }
    }

    private void RestartLevel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Scene _scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(_scene.name);
            ClearLog();
        }
    }

    public void ClearLog()
    {
        var _assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var _type = _assembly.GetType("UnityEditor.LogEntries");
        var _method = _type.GetMethod("Clear");
        _method.Invoke(new object(), null);
    }
}