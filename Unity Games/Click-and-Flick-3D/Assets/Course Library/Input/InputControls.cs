//using UnityEngine;
//using UnityEngine.InputSystem;

//public class InputControls : MonoBehaviour
//{
//    private PlayerInput _playerInput;
//    private InputAction _touchClickAction;
//    private InputAction _touchTapAction;

//    private void Awake()
//    {
//        _playerInput = GetComponent<PlayerInput>();
//        _touchClickAction = _playerInput.actions.FindAction("Click");
//        _touchTapAction = _playerInput.actions.FindAction("Tap");
//    }

//    private void OnEnable()
//    {
//        _touchClickAction.performed += OnClick;
//        _touchTapAction.performed += OnTap;
//    }

//    private void OnDisable()
//    {
//        _touchClickAction.performed -= OnClick;
//        _touchTapAction.performed -= OnTap;
//    }

//    private void OnClick(InputAction.CallbackContext context)
//    {
//        if (_gameManager._isGameStart)
//        {
//            _clickSoundSource.Play();
//            Destroy(gameObject);
//            Instantiate(_explosionParticle, transform.position, transform.rotation);
//            _gameManager.UpdateScore(_pointValue);
//        }
//    }

//    private void OnTap(InputAction.CallbackContext context)
//    {
//        if (_gameManager._isGameStart)
//        {
//            _clickSoundSource.Play();
//            Destroy(gameObject);
//            Instantiate(_explosionParticle, transform.position, transform.rotation);
//            _gameManager.UpdateScore(_pointValue);
//        }
//    }
//}