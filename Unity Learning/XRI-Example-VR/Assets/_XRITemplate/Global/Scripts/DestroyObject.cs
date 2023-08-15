using UnityEngine;

namespace Unity.XRContent.Interaction
{
    /// <summary>
    /// Destroys object after a few seconds
    /// </summary>
    public class DestroyObject : MonoBehaviour
    {
        [Tooltip("Time before destroying in seconds")]
        float m_LifeTime = 5.0f;

        void Start()
        {
            Destroy(gameObject, m_LifeTime);
        }
    }
}
