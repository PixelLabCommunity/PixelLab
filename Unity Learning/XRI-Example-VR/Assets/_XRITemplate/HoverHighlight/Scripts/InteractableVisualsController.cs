using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Unity.SpatialFramework.Rendering
{
    /// <summary>
    /// All-in-one controller for animated object highlights in different states - hovered, selected, and activated
    /// </summary>
    public class InteractableVisualsController : MonoBehaviour
    {
        const float k_ShineTime = 0.2f;

#pragma warning disable 649
        [SerializeField]
        [Tooltip("The hover audio source.")]
        AudioSource m_AudioHover;

        [SerializeField]
        [Tooltip("The click audio source.")]
        AudioSource m_AudioClick;

        [SerializeField]
        [Tooltip("Material capture settings")]
        HighlightController m_HighlightController = new HighlightController();

        [SerializeField]
        [Tooltip("The outline highlight for selection.")]
        OutlineHighlight m_OutlineHighlight;

        [SerializeField]
        [Tooltip("The material highlight for hover.")]
        MaterialHighlight m_MaterialHighlight;

        [SerializeField]
        [Tooltip("The outline hover color.")]
        Color m_HoverColor = new Color(0.09411765f, 0.4392157f, 0.7137255f, 1f);

        [SerializeField]
        [Tooltip("The outline selection color.")]
        Color m_SelectionColor = new Color(1f, 0.4f, 0f, 1f);

        [SerializeField]
        [Tooltip("To play material activate anim.")]
        bool m_PlayMaterialActivateAnim = false;

        [SerializeField]
        [Tooltip("To play outline activate anim.")]
        bool m_PlayOutlineActivateAnim = false;

        [SerializeField]
        [Tooltip("If true, the highlight state will be on during hover")]
        bool m_HighlightOnHover = true;

        [SerializeField]
        [Tooltip("If true, the highlight state will be on during select")]
        bool m_HighlightOnSelect = true;

        [SerializeField]
        [Tooltip("If true, the highlight state will be on during activate")]
        bool m_HighlightOnActivate = true;

#pragma warning restore 649

        IXRInteractable m_Interactable;

        Transform m_Transform;
        Material m_PulseMaterial;
        float m_StartingAlpha;
        float m_StartingWidth;

        bool m_Activated;
        bool m_Selected;
        bool m_Hovered;
        bool m_Highlighting = false;

        bool m_PlayShine = false;
        float m_ShineTimer = 0.0f;

        void Awake()
        {
            // Find the grab interactable
            m_Interactable = GetComponentInParent<XRBaseInteractable>();

            // Hook up to events
            if (m_Interactable is IXRHoverInteractable hoverInteractable)
            {
                hoverInteractable.hoverEntered.AddListener(PerformEntranceActions);
                hoverInteractable.hoverExited.AddListener(PerformExitActions);
            }

            if (m_Interactable is IXRSelectInteractable selectInteractable)
            {
                selectInteractable.selectEntered.AddListener(PerformSelectEnteredActions);
                selectInteractable.selectExited.AddListener(PerformSelectExitedActions);
            }

            if (m_Interactable is IXRActivateInteractable activateInteractable)
            {
                activateInteractable.activated.AddListener(PerformActivatedActions);
                activateInteractable.deactivated.AddListener(PerformDeactivatedActions);
            }

            // Cache materials for highlighting
            m_HighlightController.RendererSource = m_Interactable.transform;

            // Tell the highlight objects to get renderers starting at the grab interactable down
            if (m_MaterialHighlight != null)
            {
                m_HighlightController.RegisterCacheUser(m_MaterialHighlight);
                m_PulseMaterial = m_MaterialHighlight.HighlightMaterial;

                if (m_PulseMaterial != null)
                    m_StartingAlpha = m_PulseMaterial.GetFloat("_PulseMinAlpha");
            }
            if (m_OutlineHighlight != null)
                m_HighlightController.RegisterCacheUser(m_OutlineHighlight);

            m_HighlightController.Initialize();
            m_StartingWidth = m_OutlineHighlight.outlineScale;
        }

        void Update()
        {
            m_HighlightController.Update();
            if (m_MaterialHighlight != null)
            {
                if (m_Hovered || m_Selected)
                {
                    if (m_Transform == null)
                    {
                        Debug.LogWarning($"Interactor of {m_Interactable.transform.name} does not have transform set properly", this);
                    }
                    else
                    {
                        Vector4 vec = m_Transform.position;
                        m_PulseMaterial.SetVector("_Center", vec);
                    }
                }

                // Do timer count up/count down
                if (m_PlayShine)
                {
                    m_ShineTimer += Time.deltaTime;

                    var shinePercent = Mathf.Clamp01(m_ShineTimer / k_ShineTime);
                    var shineValue = Mathf.PingPong(shinePercent, 0.5f) * 2.0f;

                    m_PulseMaterial.SetFloat("_PulseMinAlpha", Mathf.Lerp(m_StartingAlpha, 1f, shineValue));

                    if (shinePercent >= 1.0f)
                    {
                        m_PlayShine = false;
                        m_ShineTimer = 0.0f;
                    }
                }
            }
        }

        void UpdateHighlightState()
        {
            var shouldHighlight = false;

            if (m_Activated)
                shouldHighlight = m_HighlightOnActivate;
            else
            {
                if (m_Selected)
                    shouldHighlight = m_HighlightOnSelect;
                else
                {
                    if (m_Hovered)
                        shouldHighlight = m_HighlightOnHover;
                }
            }

            if (shouldHighlight == m_Highlighting)
                return;

            m_Highlighting = shouldHighlight;

            if (m_Highlighting)
                m_HighlightController.Highlight();
            else
                m_HighlightController.Unhighlight();
        }

        void PerformEntranceActions(HoverEnterEventArgs args)
        {
            if (args.interactorObject is XRSocketInteractor)
                return;

            if (m_Selected && m_Transform != null)
                return;

            m_Transform = args.interactorObject.transform;

            if (m_AudioHover != null)
                m_AudioHover.Play();

            if (m_MaterialHighlight != null)
                m_PulseMaterial.color = m_HoverColor;

            if (m_OutlineHighlight != null)
                m_OutlineHighlight.outlineColor = m_HoverColor;

            m_Hovered = true;
            UpdateHighlightState();
        }

        void PerformExitActions(HoverExitEventArgs args)
        {
            if (args.interactorObject is XRSocketInteractor)
                return;

            if (args.interactorObject.transform != m_Transform)
                return;

            m_Hovered = false;
            UpdateHighlightState();
        }

        void PerformSelectEnteredActions(SelectEnterEventArgs args)
        {
            if (args.interactorObject is XRSocketInteractor)
                return;

            m_Transform = args.interactorObject.transform;

            if (m_AudioClick != null)
                m_AudioClick.Play();

            if (m_OutlineHighlight != null)
            {
                m_OutlineHighlight.outlineColor = m_SelectionColor;
                m_OutlineHighlight.PlayPulseAnimation();
            }

            if (m_MaterialHighlight != null)
                m_PulseMaterial.color = m_SelectionColor;

            m_Selected = true;
            UpdateHighlightState();
        }

        void PerformSelectExitedActions(SelectExitEventArgs args)
        {
            if (args.interactorObject is XRSocketInteractor)
                return;

            if (m_OutlineHighlight != null)
                m_OutlineHighlight.outlineColor = m_HoverColor;
            if (m_MaterialHighlight != null)
                m_PulseMaterial.color = m_HoverColor;

            m_OutlineHighlight.PlayPulseAnimation();

            m_Selected = false;
            UpdateHighlightState();
        }

        void PerformActivatedActions(ActivateEventArgs args)
        {
            if (args.interactorObject is XRSocketInteractor)
                return;

            m_Transform = args.interactorObject.transform;

            if (m_OutlineHighlight != null)
            {
                if (m_PlayMaterialActivateAnim)
                    m_PlayShine = true;

                if (m_PlayOutlineActivateAnim)
                {
                    m_OutlineHighlight.outlineScale = 1f;
                    m_OutlineHighlight.PlayPulseAnimation();
                }
            }
            m_Activated = true;
            UpdateHighlightState();
        }

        void PerformDeactivatedActions(DeactivateEventArgs args)
        {
            if (args.interactorObject is XRSocketInteractor)
                return;

            if (m_OutlineHighlight != null)
            {
                if (m_PlayOutlineActivateAnim)
                {
                    m_OutlineHighlight.outlineScale = m_StartingWidth;
                    m_OutlineHighlight.PlayPulseAnimation();
                }
            }
            m_Activated = false;
            UpdateHighlightState();
        }
    }
}
