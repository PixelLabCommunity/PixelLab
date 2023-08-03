using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float MovementY = 0f;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    [SerializeField] private float turnSpeed = 20f;

    private Animator _mAnimator;
    private AudioSource _mAudioSource;
    private Vector3 _mMovement;
    private Rigidbody _mRigidbody;
    private Quaternion _mRotation = Quaternion.identity;

    private void Start()
    {
        _mAnimator = GetComponent<Animator>();
        _mRigidbody = GetComponent<Rigidbody>();
        _mAudioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        _mMovement.Set(horizontal, MovementY, vertical);
        _mMovement.Normalize();

        var hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        var hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        var isWalking = hasHorizontalInput || hasVerticalInput;
        _mAnimator.SetBool(IsWalking, isWalking);

        if (isWalking)
        {
            if (!_mAudioSource.isPlaying) _mAudioSource.Play();
        }
        else
        {
            _mAudioSource.Stop();
        }

        var desiredForward = Vector3.RotateTowards(transform.forward, _mMovement, turnSpeed * Time.deltaTime, 0f);
        _mRotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        _mRigidbody.MovePosition(_mRigidbody.position + _mMovement * _mAnimator.deltaPosition.magnitude);
        _mRigidbody.MoveRotation(_mRotation);
    }
}