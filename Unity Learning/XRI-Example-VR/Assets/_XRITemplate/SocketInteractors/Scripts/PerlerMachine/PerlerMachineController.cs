using UnityEngine;

namespace Unity.XRContent.Interaction
{
    /// <summary>
    /// This class is responsible for create the perler sockets grid and change the lights state.
    /// </summary>
    public class PerlerMachineController : MonoBehaviour
    {
        const int k_GridWidth = 16;
        const int k_GridHeight = 16;

        static readonly Vector2 k_GridOffset = new Vector2(-.05666f, -.05666f);
        static readonly string k_EmissionKeyword = "_EMISSION";

        [SerializeField]
        [Tooltip("The Transform at the center of the grid, this wil be the parent of the instantiated sockets")]
        Transform m_GridCenter;

        [SerializeField]
        [Tooltip("The first instantiated socket will be placed in the same position as this transform")]
        Transform m_GridOrigin;

        [SerializeField]
        [Tooltip("The socket prefab to be instantiated in the grid")]
        GameObject m_GridSocketPrefab;

        [SerializeField]
        [Tooltip("The emissive materials that will change state whenever the machine is turned on/off")]
        Material[] m_EmissiveMaterials;

        bool m_MachineActive;

        void Awake()
        {
            CreateGrid();
            DisableEmissiveMaterials();
        }

#if UNITY_EDITOR
        void OnDestroy()
        {
            EnableEmissiveMaterials();
        }

#endif

        void CreateGrid()
        {
            var origin = m_GridOrigin.position;

            for (var i = 0; i < k_GridHeight; i++)
            {
                for (var j = 0; j < k_GridWidth; j++)
                {
                    var socketInstance = Instantiate(m_GridSocketPrefab, origin, m_GridCenter.rotation, m_GridCenter);
                    socketInstance.name = $"{m_GridSocketPrefab.name} ({i},{j})";

                    var socketOffset = new Vector3(j * k_GridOffset.x, i * k_GridOffset.y, 0f);
                    socketInstance.transform.localPosition += socketOffset;
                }
            }
        }

        void DisableEmissiveMaterials()
        {
            foreach (var material in m_EmissiveMaterials)
                material.DisableKeyword(k_EmissionKeyword);
        }

        void EnableEmissiveMaterials()
        {
            foreach (var material in m_EmissiveMaterials)
                material.EnableKeyword(k_EmissionKeyword);
        }

        /// <summary>
        /// Call this method to activate or deactivate the machine. This will change the lights state.
        /// Used by the BatterySlot GameObject socket.
        /// </summary>
        /// <param name="active">True to activate the machine; false otherwise.</param>
        public void SetMachineActive(bool active)
        {
            // It's the same state?
            if (active == m_MachineActive)
                return;

            // Change the machine light state
            m_MachineActive = active;
            if (m_MachineActive)
                EnableEmissiveMaterials();
            else
                DisableEmissiveMaterials();
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.matrix = m_GridOrigin.localToWorldMatrix;
            for (var i = 0; i < k_GridHeight; i++)
            {
                for (var j = 0; j < k_GridWidth; j++)
                {
                    var currentPosition = new Vector3(j * k_GridOffset.x, i * k_GridOffset.y, 0f);
                    Gizmos.DrawLine(currentPosition + (Vector3.left * k_GridOffset.x * 0.5f), currentPosition + (Vector3.right * k_GridOffset.y * 0.5f));
                    Gizmos.DrawLine(currentPosition + (Vector3.down * k_GridOffset.x * 0.5f), currentPosition + (Vector3.up * k_GridOffset.y * 0.5f));
                }
            }
        }
    }
}
