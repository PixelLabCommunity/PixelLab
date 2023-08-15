using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Unity.XRContent.Interaction
{
    /// <summary>
    /// Use this class to present locomotion control schemes and configuration preferences,
    /// and respond to player input in the UI to set them.
    /// </summary>
    /// <seealso cref="XRRigLocomotionManager"/>
    public class LocomotionSetup : MonoBehaviour
    {
        const float k_MaxMoveSpeed = 5.0f;
        const float k_MinMoveSpeed = 0.5f;

        const string k_SpeedFormat = "###.0";
        const string k_DegreeFormat = "###";
        const string k_SpeedLabel = " m/s";
        const string k_DegreeLabel = "°/s";

        const string k_GravityLabel = "Rig Gravity";

        [SerializeField]
        [Tooltip("Stores the behavior that will be used to configure locomotion control schemes and configuration preferences.")]
        XRRigLocomotionManager m_Manager;

        [SerializeField]
        [Tooltip("Stores the toggle lever used to enable or disable continuous movement locomotion for the left hand.")]
        XRLever m_LeftHandMovementToggle;

        [SerializeField]
        [Tooltip("Stores the toggle lever used to enable or disable continuous movement locomotion for the right hand.")]
        XRLever m_RightHandMovementToggle;

        [SerializeField]
        [Tooltip("Stores the toggle lever used to enable or disable continuous turning for the left hand.")]
        XRLever m_LeftHandTurnToggle;

        [SerializeField]
        [Tooltip("Stores the toggle lever used to enable or disable continuous turning for the right hand.")]
        XRLever m_RightHandTurnToggle;

        [SerializeField]
        [Tooltip("Stores the Slider used to set the move speed of continuous movement.")]
        XRSlider m_MoveSpeedSlider;

        [SerializeField]
        [Tooltip("Stores the button toggle used to enable strafing movement.")]
        XRPushButton m_StrafeToggle;

        [SerializeField]
        [Tooltip("Stores the button toggle used to switch between camera and controller movement direction.")]
        XRPushButton m_DirectionToggle;

        [SerializeField]
        [Tooltip("Stores the button toggle used to enable gravity.")]
        XRPushButton m_GravityToggle;

        [SerializeField]
        [Tooltip("Stores the knob used to set turn speed.")]
        XRKnob m_TurnSpeedKnob;

        [SerializeField]
        [Tooltip("Stores the button toggle used to enable instant turn-around.")]
        XRPushButton m_TurnAroundToggle;

        [SerializeField]
        [Tooltip("Stores the knob used to set snap turn around.")]
        XRKnob m_SnapTurnKnob;

        [SerializeField]
        [Tooltip("The label that shows the current movement speed value.")]
        TextMeshPro m_MoveSpeedLabel;

        [SerializeField]
        [Tooltip("The label that shows the current turn speed value.")]
        TextMeshPro m_TurnSpeedLabel;

        [SerializeField]
        [Tooltip("The label that shows the current snap turn value.")]
        TextMeshPro m_SnapTurnLabel;

        [SerializeField]
        [Tooltip("The label that shows the current strafe toggle value.")]
        TextMeshPro m_StrafeLabel;

        [SerializeField]
        [Tooltip("The label that shows the current direction control toggle value.")]
        TextMeshPro m_DirectionLabel;

        [SerializeField]
        [Tooltip("The label that shows the current gravity toggle value.")]
        TextMeshPro m_GravityLabel;

        [SerializeField]
        [Tooltip("The label that shows the current turnaround toggle value.")]
        TextMeshPro m_TurnAroundLabel;

        void InitializeControls()
        {
            m_LeftHandMovementToggle.Value = (m_Manager.LeftHandMoveScheme == XRRigLocomotionManager.MoveScheme.Smooth);
            m_RightHandMovementToggle.Value = (m_Manager.RightHandMoveScheme == XRRigLocomotionManager.MoveScheme.Smooth);

            m_LeftHandTurnToggle.Value = (m_Manager.LeftHandTurnStyle == XRRigLocomotionManager.TurnStyle.Smooth);
            m_RightHandTurnToggle.Value = (m_Manager.RightHandTurnStyle == XRRigLocomotionManager.TurnStyle.Smooth);

            m_MoveSpeedSlider.Value = Mathf.InverseLerp(k_MinMoveSpeed, k_MaxMoveSpeed, m_Manager.SmoothMoveProvider.moveSpeed);
            m_StrafeToggle.ToggleValue = m_Manager.SmoothMoveProvider.enableStrafe;
            m_DirectionToggle.ToggleValue = m_Manager.SmoothMoveProvider.HeadDrivesMotion;
            m_GravityToggle.ToggleValue = m_Manager.SmoothMoveProvider.useGravity;

            m_TurnSpeedKnob.Value = m_Manager.SmoothTurnProvider.turnSpeed;
            m_TurnAroundToggle.ToggleValue = m_Manager.SnapTurnProvider.enableTurnAround;
            m_SnapTurnKnob.Value = m_Manager.SnapTurnProvider.turnAmount;

            m_MoveSpeedLabel.text = $"{m_Manager.SmoothMoveProvider.moveSpeed}{k_SpeedLabel}";
            m_TurnSpeedLabel.text = $"{m_Manager.SmoothTurnProvider.turnSpeed}{k_DegreeLabel}";
            m_SnapTurnLabel.text = $"{m_Manager.SnapTurnProvider.turnAmount}{k_DegreeLabel}";

            m_StrafeLabel.text = $"Strafe\n{(m_Manager.SmoothMoveProvider.enableStrafe ? "enabled" : "disabled")}";
            m_DirectionLabel.text = $"Move via\n{(m_Manager.SmoothMoveProvider.HeadDrivesMotion ? "Camera" : "Controllers")}";
            m_GravityLabel.text = $"{k_GravityLabel}\n{(m_Manager.SmoothMoveProvider.useGravity ? "enabled" : "disabled")}";
            m_TurnAroundLabel.text = $"Turn around \n{(m_Manager.SnapTurnProvider.enableTurnAround ? "enabled" : "disabled")}";
        }

        void ConnectControlEvents()
        {
            m_LeftHandMovementToggle.OnLeverActivate.AddListener(EnableLeftHandSmoothMove);
            m_LeftHandMovementToggle.OnLeverDeactivate.AddListener(EnableLeftHandTeleportMove);
            m_RightHandMovementToggle.OnLeverActivate.AddListener(EnableRightHandSmoothMove);
            m_RightHandMovementToggle.OnLeverDeactivate.AddListener(EnableRightHandTeleportMove);

            m_LeftHandTurnToggle.OnLeverActivate.AddListener(EnableLeftHandContinuousTurn);
            m_LeftHandTurnToggle.OnLeverDeactivate.AddListener(EnableLeftHandSnapTurn);
            m_RightHandTurnToggle.OnLeverActivate.AddListener(EnableRightHandContinuousTurn);
            m_RightHandTurnToggle.OnLeverDeactivate.AddListener(EnableRightHandSnapTurn);

            m_MoveSpeedSlider.OnValueChange.AddListener(SetMoveSpeed);
            m_StrafeToggle.OnPress.AddListener(EnableStrafe);
            m_StrafeToggle.OnRelease.AddListener(DisableStrafe);
            m_DirectionToggle.OnPress.AddListener(EnableCameraMotion);
            m_DirectionToggle.OnRelease.AddListener(EnableControllerMotion);
            m_GravityToggle.OnPress.AddListener(EnableGravity);
            m_GravityToggle.OnRelease.AddListener(DisableGravity);

            m_TurnSpeedKnob.OnValueChange.AddListener(SetTurnSpeed);
            m_TurnAroundToggle.OnPress.AddListener(EnableTurnAround);
            m_TurnAroundToggle.OnRelease.AddListener(DisableTurnAround);
            m_SnapTurnKnob.OnValueChange.AddListener(SetSnapTurnAmount);
        }

        void DisconnectControlEvents()
        {
            m_LeftHandMovementToggle.OnLeverActivate.RemoveListener(EnableLeftHandSmoothMove);
            m_LeftHandMovementToggle.OnLeverDeactivate.RemoveListener(EnableLeftHandTeleportMove);
            m_RightHandMovementToggle.OnLeverActivate.RemoveListener(EnableRightHandSmoothMove);
            m_RightHandMovementToggle.OnLeverDeactivate.RemoveListener(EnableRightHandTeleportMove);

            m_LeftHandTurnToggle.OnLeverActivate.RemoveListener(EnableLeftHandContinuousTurn);
            m_LeftHandTurnToggle.OnLeverDeactivate.RemoveListener(EnableLeftHandSnapTurn);
            m_RightHandTurnToggle.OnLeverActivate.RemoveListener(EnableRightHandContinuousTurn);
            m_RightHandTurnToggle.OnLeverDeactivate.RemoveListener(EnableRightHandSnapTurn);

            m_MoveSpeedSlider.OnValueChange.RemoveListener(SetMoveSpeed);
            m_StrafeToggle.OnPress.RemoveListener(EnableStrafe);
            m_StrafeToggle.OnRelease.RemoveListener(DisableStrafe);
            m_GravityToggle.OnPress.RemoveListener(EnableGravity);
            m_GravityToggle.OnRelease.RemoveListener(DisableGravity);

            m_TurnSpeedKnob.OnValueChange.RemoveListener(SetTurnSpeed);
            m_TurnAroundToggle.OnPress.RemoveListener(EnableTurnAround);
            m_TurnAroundToggle.OnRelease.RemoveListener(DisableTurnAround);
            m_SnapTurnKnob.OnValueChange.RemoveListener(SetSnapTurnAmount);
        }

        protected void OnEnable()
        {
            if (!ValidateManager())
                return;

            ConnectControlEvents();
            InitializeControls();
        }

        protected void OnDisable()
        {
            DisconnectControlEvents();
        }

        bool ValidateManager()
        {
            if (m_Manager == null)
            {
                Debug.LogError($"Reference to the {nameof(XRRigLocomotionManager)} is not set or the object has been destroyed," +
                    " configuring locomotion settings from the menu will not be possible." +
                    " Ensure the value has been set in the Inspector.", this);
                return false;
            }

            if (m_Manager.SmoothMoveProvider == null)
            {
                Debug.LogError($"Reference to the {nameof(XRRigLocomotionManager)} is not set or the object has been destroyed," +
                    " configuring locomotion settings from the menu will not be possible." +
                    $" Ensure the value has been set in the Inspector on {m_Manager}.", this);
                return false;
            }

            if (m_Manager.SmoothTurnProvider == null)
            {
                Debug.LogError($"Reference to the {nameof(XRRigLocomotionManager)} is not set or the object has been destroyed," +
                    " configuring locomotion settings from the menu will not be possible." +
                    $" Ensure the value has been set in the Inspector on {m_Manager}.", this);
                return false;
            }

            if (m_Manager.SnapTurnProvider == null)
            {
                Debug.LogError($"Reference to the {nameof(XRRigLocomotionManager)} is not set or the object has been destroyed," +
                    " configuring locomotion settings from the menu will not be possible." +
                    $" Ensure the value has been set in the Inspector on {m_Manager}.", this);
                return false;
            }

            return true;
        }

        void EnableLeftHandSmoothMove()
        {
            m_Manager.LeftHandMoveScheme = XRRigLocomotionManager.MoveScheme.Smooth;
        }

        void EnableRightHandSmoothMove()
        {
            m_Manager.RightHandMoveScheme = XRRigLocomotionManager.MoveScheme.Smooth;
        }

        void EnableLeftHandTeleportMove()
        {
            m_Manager.LeftHandMoveScheme = XRRigLocomotionManager.MoveScheme.Teleport;
        }

        void EnableRightHandTeleportMove()
        {
            m_Manager.RightHandMoveScheme = XRRigLocomotionManager.MoveScheme.Teleport;
        }

        void EnableLeftHandContinuousTurn()
        {
            m_Manager.LeftHandTurnStyle = XRRigLocomotionManager.TurnStyle.Smooth;
        }

        void EnableRightHandContinuousTurn()
        {
            m_Manager.RightHandTurnStyle = XRRigLocomotionManager.TurnStyle.Smooth;
        }

        void EnableLeftHandSnapTurn()
        {
            m_Manager.LeftHandTurnStyle = XRRigLocomotionManager.TurnStyle.Snap;
        }

        void EnableRightHandSnapTurn()
        {
            m_Manager.RightHandTurnStyle = XRRigLocomotionManager.TurnStyle.Snap;
        }

        void SetMoveSpeed(float sliderValue)
        {
            m_Manager.SmoothMoveProvider.moveSpeed = Mathf.Lerp(k_MinMoveSpeed, k_MaxMoveSpeed, sliderValue);
            m_MoveSpeedLabel.text = $"{m_Manager.SmoothMoveProvider.moveSpeed.ToString(k_SpeedFormat)}{k_SpeedLabel}";
        }

        void EnableStrafe()
        {
            m_Manager.SmoothMoveProvider.enableStrafe = true;
            m_StrafeLabel.text = $"Strafe\n{(m_Manager.SmoothMoveProvider.enableStrafe ? "enabled" : "disabled")}";
        }

        void DisableStrafe()
        {
            m_Manager.SmoothMoveProvider.enableStrafe = false;
            m_StrafeLabel.text = $"Strafe\n{(m_Manager.SmoothMoveProvider.enableStrafe ? "enabled" : "disabled")}";
        }

        void EnableCameraMotion()
        {
            m_Manager.SmoothMoveProvider.HeadDrivesMotion = true;
            m_DirectionLabel.text = $"Move via\n{(m_Manager.SmoothMoveProvider.HeadDrivesMotion ? "Camera" : "Controllers")}";
        }

        void EnableControllerMotion()
        {
            m_Manager.SmoothMoveProvider.HeadDrivesMotion = false;
            m_DirectionLabel.text = $"Move via\n{(m_Manager.SmoothMoveProvider.HeadDrivesMotion ? "Camera" : "Controllers")}";
        }

        void EnableGravity()
        {
            m_Manager.SmoothMoveProvider.useGravity = true;
            m_Manager.SmoothMoveProvider.gravityApplicationMode = ContinuousMoveProviderBase.GravityApplicationMode.AttemptingMove;
            m_GravityLabel.text = $"{k_GravityLabel}\n{(m_Manager.SmoothMoveProvider.useGravity ? "enabled" : "disabled")}";
        }

        void DisableGravity()
        {
            m_Manager.SmoothMoveProvider.useGravity = false;
            m_GravityLabel.text = $"{k_GravityLabel}\n{(m_Manager.SmoothMoveProvider.useGravity ? "enabled" : "disabled")}";
        }

        void SetTurnSpeed(float knobValue)
        {
            m_Manager.SmoothTurnProvider.turnSpeed = Mathf.Lerp(m_TurnSpeedKnob.MinAngle, m_TurnSpeedKnob.MaxAngle, knobValue);
            m_TurnSpeedLabel.text = $"{m_Manager.SmoothTurnProvider.turnSpeed.ToString(k_DegreeFormat)}{k_DegreeLabel}";
        }

        void EnableTurnAround()
        {
            m_Manager.SnapTurnProvider.enableTurnAround = true;
            m_TurnAroundLabel.text = $"Turn around \n{(m_Manager.SnapTurnProvider.enableTurnAround ? "enabled" : "disabled")}";
        }

        void DisableTurnAround()
        {
            m_Manager.SnapTurnProvider.enableTurnAround = false;
            m_TurnAroundLabel.text = $"Turn around \n{(m_Manager.SnapTurnProvider.enableTurnAround ? "enabled" : "disabled")}";
        }

        void SetSnapTurnAmount(float newAmount)
        {
            m_Manager.SnapTurnProvider.turnAmount = Mathf.Lerp(m_SnapTurnKnob.MinAngle, m_SnapTurnKnob.MaxAngle, newAmount);
            m_SnapTurnLabel.text = $"{m_Manager.SnapTurnProvider.turnAmount.ToString(k_DegreeFormat)}{k_DegreeLabel}";
        }
    }
}
