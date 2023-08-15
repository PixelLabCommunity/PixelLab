using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.SpatialFramework.Walkthrough
{
    /// <summary>
    /// Manipulates a line renderer to draw a curved path between two locations
    /// </summary>
    [RequireComponent(typeof(LineRenderer))]
    public class WaypointCurve : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField]
        [Tooltip("Where the curved path should begin.")]
        Transform m_StartPoint;

        [SerializeField]
        [Tooltip("Where the curved path should complete.")]
        Transform m_EndPoint;

        [SerializeField]
        [Tooltip("Bends the first control point of the path.")]
        float m_CurveFactorStart = 1.0f;

        [SerializeField]
        [Tooltip("Bends the last control point of the path.")]
        float m_CurveFactorEnd = 1.0f;

        [SerializeField]
        [Tooltip("Enable to make the path animate colors.")]
        bool m_Animate = false;

        [SerializeField]
        [Tooltip("How quickly to animate the path.")]
        float m_AnimSpeed = 0.25f;
#pragma warning restore 649

        Vector3[] m_ControlPoints = new Vector3[4];
        LineRenderer m_LineRenderer;
        int m_CurveCount = 0;
        int layerOrder = 0;
        int SEGMENT_COUNT = 50;
        float time = 0.0f;

        public Vector3 start
        {
            get { return m_StartPoint.position; }
            set { m_StartPoint.position = value; }
        }

        public Vector3 end
        {
            get { return m_EndPoint.position; }
            set { m_EndPoint.position = value; }
        }

        void Start()
        {
            if (!m_LineRenderer)
            {
                m_LineRenderer = GetComponent<LineRenderer>();
            }
            m_LineRenderer.sortingLayerID = layerOrder;
            m_CurveCount = (int)4 / 3;
        }

        void Update()
        {
            DrawCurve();

            if (m_Animate) { AnimateCurve(); }
        }

        void DrawCurve()
        {
            var dist = Mathf.Clamp(Vector3.Distance(m_StartPoint.position, m_EndPoint.position), 0f, 1f);
            m_ControlPoints[0] = m_StartPoint.position;
            m_ControlPoints[1] = m_StartPoint.position + m_StartPoint.right * (dist * m_CurveFactorStart);
            m_ControlPoints[2] = m_EndPoint.position - m_EndPoint.right * (dist * m_CurveFactorEnd);
            m_ControlPoints[3] = m_EndPoint.position;

            for (int j = 0; j < m_CurveCount; j++)
            {
                for (int i = 1; i <= SEGMENT_COUNT; i++)
                {
                    float t = i / (float)SEGMENT_COUNT;
                    int nodeIndex = j * 3;
                    Vector3 pixel = CalculateCubicBezierPoint(t, m_ControlPoints[nodeIndex], m_ControlPoints[nodeIndex + 1], m_ControlPoints[nodeIndex + 2], m_ControlPoints[nodeIndex + 3]);
                    m_LineRenderer.positionCount = (((j * SEGMENT_COUNT) + i));
                    m_LineRenderer.SetPosition((j * SEGMENT_COUNT) + (i - 1), pixel);
                }
            }
        }

        Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            float uuu = uu * u;
            float ttt = tt * t;

            Vector3 p = uuu * p0;
            p += 3 * uu * t * p1;
            p += 3 * u * tt * p2;
            p += ttt * p3;

            return p;
        }

        void AnimateCurve()
        {
            Gradient newGrad = new Gradient();

            GradientColorKey[] colorKeys = new GradientColorKey[1];
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];

            GradientColorKey colorKey = new GradientColorKey(new Color(0.1254902f, 0.5882353f, 0.9529412f), 0f);
            colorKeys[0] = colorKey;

            GradientAlphaKey alphaKeyStart1 = new GradientAlphaKey(.25f, time);
            GradientAlphaKey alphaKeyStart = new GradientAlphaKey(.25f, time);
            GradientAlphaKey alphaKeyEnd = new GradientAlphaKey(1f, 1f);
            alphaKeys[0] = alphaKeyStart;
            alphaKeys[1] = alphaKeyEnd;

            newGrad.SetKeys(colorKeys, alphaKeys);
            newGrad.mode = GradientMode.Blend;

            m_LineRenderer.colorGradient = newGrad;
            time += (Time.deltaTime * m_AnimSpeed);

            if (time >= 1f)
            {
                time = 0f;
            }
        }
    }
}
