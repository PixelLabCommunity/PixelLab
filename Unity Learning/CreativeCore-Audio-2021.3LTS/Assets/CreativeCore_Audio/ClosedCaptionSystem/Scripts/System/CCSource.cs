using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CCsystem;
using UnityEditor;
using UnityEngine;

namespace CCSystem
{
    /// <summary>
    /// If an object with an AudioSource have a CCSource, it will be tracked by the CCManager and its current playing clip
    /// will be lookup on the current CCManager's CCDatabase so the right line can be displayed for the current play time
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class CCSource : MonoBehaviour
    {
        public CCCanvas CanvasPrefab;
    
        public bool AlwaysTracked;
        public float MaxDistance = 4.0f;
        public float Scale = 1.0f;
        public bool DynamicScale = false;
        public Vector3 RootOffset = Vector3.zero;
        
        public bool Displayed => m_Displayed;
        public bool IsPlaying => m_Source.isPlaying;

        AudioSource m_Source;
        bool m_Displayed = false;
        CCCanvas m_Canvas;
        private Vector3 m_OriginalScale;

        void Start()
        {
            m_Source = GetComponentInChildren<AudioSource>();
            m_Canvas = Instantiate(CanvasPrefab, transform, false);
            
            m_Canvas.transform.localPosition = RootOffset;

            m_OriginalScale = m_Canvas.transform.localScale;
        
            Hide();
        }

        void OnEnable()
        {
            CCManager.RegisterSource(this);
        }

        void OnDisable()
        {
            CCManager.RemoveSource(this);
        }

        public void Display(Vector3 toCamera, float distance, CCDatabase database)
        {
            if (m_Source.clip == null)
                return;

            if (!m_Displayed)
            {
                m_Displayed = true;
                m_Canvas.gameObject.SetActive(true);
            }

            float finalScale = Scale;
            if (DynamicScale)
                finalScale *= distance / MaxDistance;
                
            m_Canvas.transform.localScale = m_OriginalScale * finalScale;

            m_Canvas.transform.forward = toCamera;

            string entry = database.GetTextEntry(m_Source.clip, m_Source.time);
            m_Canvas.CCText.text = entry;
        }

        public void Hide()
        {
            m_Displayed = false;
            m_Canvas.gameObject.SetActive(false);
        }

        public void SetLine(string line)
        {
            m_Canvas.CCText.text = line;
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            //we only want to draw the CC preview if that object is DIRECTLY selected and not its parent
            if(!Selection.gameObjects.Contains(gameObject))
                return;

            Vector3 worldPos = transform.TransformPoint(RootOffset);
            
            Handles.matrix = Matrix4x4.LookAt(worldPos, Camera.current.transform.position, Vector3.up);
            Handles.DrawSolidRectangleWithOutline(new Rect(-1, -0.25f, 2, 0.5f), new Color(1.0f,1.0f,1.0f,0.3f), Color.red);
        }
#endif
    }
}