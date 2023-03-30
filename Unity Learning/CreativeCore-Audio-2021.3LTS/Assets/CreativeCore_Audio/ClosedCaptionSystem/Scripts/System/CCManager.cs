using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CCSystem
{
    /// <summary>
    /// The CCManager will track each CCSource in the scene and hide/display/align them based on the view direction and
    /// distance.
    /// Note: It uses a world space canvas in front of the camera instead of an overlay canvas so its compatible with VR 
    /// </summary>
    [DefaultExecutionOrder(9999)] //executed the latest possible, to be sure all camera move where done before we move the canvas.
    public class CCManager : MonoBehaviour
    {
        static List<CCSource> s_Sources = new List<CCSource>();
        
        static CCManager s_Instance;
        public static CCManager Instance => s_Instance;

        public CCDatabase Database;
        public Canvas IndicatorCanvas;
        public GameObject IndicatorPrefab;

        public GameObject TrackedForPos;

        
        Camera m_Camera;

        Queue<GameObject> m_IndicatorQueue = new Queue<GameObject>();
        Dictionary<CCSource, GameObject> m_IndicatorMap = new Dictionary<CCSource, GameObject>();

        // Start is called before the first frame update
        void Awake()
        {
            if (s_Instance != null && s_Instance != this)
            {
                Destroy(this);
                return;
            }
        
            s_Instance = this;
        }

        void Start()
        {
            m_Camera = Camera.main;
            Database.BuildMap();

            const int indicatorPool = 8;
            for(int i = 0; i < indicatorPool; ++i)
            {
                var indicator = Instantiate(IndicatorPrefab, IndicatorCanvas.transform);
                indicator.transform.localPosition = Vector3.zero;
                indicator.transform.localRotation= Quaternion.identity;
            
                indicator.SetActive(false);
                m_IndicatorQueue.Enqueue(indicator);
            }
        }

        void OnDisable()
        {
            for (int i = 0; i < s_Sources.Count; ++i)
            {
                if(s_Sources[i].Displayed)
                    s_Sources[i].Hide();
            }
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 cameraPosition = TrackedForPos.transform.position;
            Vector3 cameraForward = TrackedForPos.transform.forward;

            for (int i = 0; i < s_Sources.Count; ++i)
            {
                if (s_Sources[i].IsPlaying)
                {
                    Vector3 toObject = s_Sources[i].transform.position - cameraPosition;
                    float distance = toObject.magnitude;
                
                    toObject.Normalize();
                    float angle = Vector3.Dot(toObject, cameraForward);

                    if (distance <= s_Sources[i].MaxDistance && angle > 0.6f)
                    {
                        // facing camera
                        s_Sources[i].Display(toObject, distance, Database);

                        if (s_Sources[i].AlwaysTracked)
                        {
                            GameObject indicator;
                            if (m_IndicatorMap.TryGetValue(s_Sources[i], out indicator))
                            {
                                indicator.SetActive(false);
                                m_IndicatorQueue.Enqueue(indicator);
                                m_IndicatorMap.Remove(s_Sources[i]);
                            }
                        }
                    }
                    else
                    {
                        //not facing
                        if (s_Sources[i].Displayed)
                            s_Sources[i].Hide();

                        if (s_Sources[i].AlwaysTracked)
                        {
                            //display a center pointer toward the source
                            GameObject indicator;
                            if (!m_IndicatorMap.TryGetValue(s_Sources[i], out indicator) && m_IndicatorQueue.Count > 0)
                            {
                                var newInd = m_IndicatorQueue.Dequeue();
                                m_IndicatorMap[s_Sources[i]] = newInd;
                                indicator = newInd;
                                indicator.SetActive(true);
                            }

                            if (indicator != null)
                            {
                                Vector3 onPlane = s_Sources[i].transform.position - IndicatorCanvas.transform.position;
                                Debug.DrawLine(IndicatorCanvas.transform.position, IndicatorCanvas.transform.position + onPlane, Color.yellow);

                                float proj = Vector3.Dot(onPlane, IndicatorCanvas.transform.forward);
                                onPlane -= proj * cameraForward;

                                Debug.DrawLine(IndicatorCanvas.transform.position, IndicatorCanvas.transform.position + onPlane.normalized * 2.0f, Color.magenta);

                                float planeAngle = Vector3.SignedAngle(IndicatorCanvas.transform.up, onPlane.normalized, cameraForward);
                                indicator.transform.localRotation = Quaternion.Euler(0, 0, planeAngle);
                            }
                        }
                    }
                }
                else
                { //source isn't playing if it got a marker, we remove it.
                
                    if(s_Sources[i].Displayed)
                        s_Sources[i].Hide();
                
                    GameObject indicator;
                    if (m_IndicatorMap.TryGetValue(s_Sources[i], out indicator))
                    {
                        indicator.SetActive(false);
                        m_IndicatorQueue.Enqueue(indicator);
                        m_IndicatorMap.Remove(s_Sources[i]);
                    }
                }
            }
        }

        private void LateUpdate()
        {
            //update canvas position to place it in front of the camera at the latest possible moment, after the camera
            //have moved but just before rendering.
            Vector3 cameraPosition = TrackedForPos.transform.position;
            Vector3 cameraForward = TrackedForPos.transform.forward;

            var t = IndicatorCanvas.transform;

            t.position = cameraPosition + cameraForward * 0.5f;
            t.forward = cameraForward;
        }

        public static void RegisterSource(CCSource source)
        {
            s_Sources.Add(source);
        }

        public static void RemoveSource(CCSource source)
        {
            s_Sources.Remove(source);
        }
    }
}