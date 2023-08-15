using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Unity.XRContent.Interaction
{
    /// <summary>
    /// A version of action based continuous movement that allows mediation between both hands, based on user preference
    /// </summary>
    public class DynamicMoveProvider : ActionBasedContinuousMoveProvider
    {
        [SerializeField]
        [Tooltip("Whether the specified head transform or controller transforms direct the rig's motion")]
        bool m_HeadDrivesMotion = true;

        [SerializeField]
        [Tooltip("Drives the motion when using look-based motion")]
        Transform m_HeadTransform;

        [SerializeField]
        [Tooltip("Drives the motion when using controller-based motion with the left hand")]
        Transform m_LeftControllerTransform;

        [SerializeField]
        [Tooltip("Drives the motion when using controller-based motion with the right hand")]
        Transform m_RightControllerTransform;

        /// <summary>
        /// Whether the specified head transform or controller transforms direct the rig's motion
        /// </summary>
        public bool HeadDrivesMotion { get => m_HeadDrivesMotion; set => m_HeadDrivesMotion = value; }

        Transform m_CombinedTransform;

        protected override void Awake()
        {
            m_CombinedTransform = new GameObject("DirectionGuide").transform;
            m_CombinedTransform.parent = transform;
            m_CombinedTransform.gameObject.hideFlags = HideFlags.HideAndDontSave;

            forwardSource = m_CombinedTransform;
        }

        protected override Vector2 ReadInput()
        {
            if (m_HeadDrivesMotion)
            {
                if (m_HeadTransform != null)
                {
                    m_CombinedTransform.position = m_HeadTransform.position;
                    m_CombinedTransform.rotation = m_HeadTransform.rotation;
                }
            }
            else
            {
                if (m_LeftControllerTransform != null && m_RightControllerTransform != null)
                {
                    var leftHandValue = leftHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;
                    var rightHandValue = rightHandMoveAction.action?.ReadValue<Vector2>() ?? Vector2.zero;

                    var totalValue = (leftHandValue.magnitude + rightHandValue.magnitude);
                    var leftHandBlend = 0.5f;

                    if (totalValue > Mathf.Epsilon)
                    {
                        leftHandBlend = leftHandValue.magnitude / totalValue;
                    }
                    m_CombinedTransform.position = Vector3.Lerp(m_RightControllerTransform.position, m_LeftControllerTransform.position, leftHandBlend);
                    m_CombinedTransform.rotation = Quaternion.Slerp(m_RightControllerTransform.rotation, m_LeftControllerTransform.rotation, leftHandBlend);
                }
            }
            return base.ReadInput();
        }
    }
}
