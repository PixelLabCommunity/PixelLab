using UnityEngine;
using UnityEngine.Events;

namespace Unity.XRContent.Animation
{
    /// <summary>
    /// Will receive triggers from the AnimationEventActionBegin/Finished classes, and forward them to Unity Events
    /// </summary>
    public class OnAnimationEvent : MonoBehaviour, IAnimationEventActionBegin, IAnimationEventActionFinished
    {
        [System.Serializable]
        struct ActionEvent
        {
            public string label;
            public UnityEvent action;
        }

        [SerializeField]
        ActionEvent[] m_ActionBeginEvents;

        [SerializeField]
        ActionEvent[] m_ActionEndEvents;

        public void ActionBegin(string label)
        {
            if (m_ActionBeginEvents == null)
                return;

            foreach (var currentAction in m_ActionBeginEvents)
            {
                if (currentAction.label == label)
                    currentAction.action.Invoke();
            }
        }

        public void ActionFinished(string label)
        {
            if (m_ActionEndEvents == null)
                return;

            foreach (var currentAction in m_ActionEndEvents)
            {
                if (currentAction.label == label)
                    currentAction.action.Invoke();
            }
        }
    }
}
