using System.Collections.Generic;
using UnityEngine;

namespace Unity.XRContent.Animation
{
    /// <summary>
    /// Provides the ability to reset specified objects if they fall below a certain position - designated by this transform's height
    /// </summary>
    public class ObjectReset : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Which objects to reset if falling out of range.")]
        List<Transform> m_ObjectsToReset = new List<Transform>();

        [SerializeField]
        [Tooltip("How often to check if objects should be reset.")]
        float m_CheckDuration = 2.0f;

        List<Pose> m_OriginalPositions = new List<Pose>();

        float m_CheckTimer = 0.0f;

        void Start()
        {
            foreach (var currentTransform in m_ObjectsToReset)
            {
                m_OriginalPositions.Add(new Pose(currentTransform.position, currentTransform.rotation));
            }
        }

        void Update()
        {
            m_CheckTimer -= Time.deltaTime;

            if (m_CheckTimer > 0)
                return;

            m_CheckTimer = m_CheckDuration;

            var resetPlane = transform.position.y;

            for (var transformIndex = 0; transformIndex < m_ObjectsToReset.Count; transformIndex++)
            {
                var currentTransform = m_ObjectsToReset[transformIndex];

                if (currentTransform == null)
                    continue;

                if (currentTransform.position.y < resetPlane)
                {
                    currentTransform.position = m_OriginalPositions[transformIndex].position;
                    currentTransform.rotation = m_OriginalPositions[transformIndex].rotation;

                    var rigidBody = currentTransform.GetComponentInChildren<Rigidbody>();
                    if (rigidBody != null)
                    {
                        rigidBody.velocity = Vector3.zero;
                        rigidBody.angularVelocity = Vector3.zero;
                    }
                }
            }
        }
    }
}
