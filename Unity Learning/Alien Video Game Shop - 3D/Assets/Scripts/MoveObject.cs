using System;
using System.Collections;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private bool isMovingToPointB = true;

    private void Start()
    {
        StartCoroutine(MoveToPoint());
    }

    private IEnumerator MoveToPoint()
    {
        while (true)
        {
            float journeyLength = Vector3.Distance(pointA.position, pointB.position);

            if (isMovingToPointB)
            {
                float startTime = Time.time;
                float distanceCovered = 0.0f;

                while (distanceCovered < journeyLength)
                {
                    float fracJourney = distanceCovered / journeyLength;
                    transform.position = Vector3.Lerp(pointA.position, pointB.position, fracJourney);
                    distanceCovered = (Time.time - startTime) * speed;
                    yield return null;
                }

                isMovingToPointB = false;
            }
            else
            {
                float startTime = Time.time;
                float distanceCovered = 0.0f;

                while (distanceCovered < journeyLength)
                {
                    float fracJourney = distanceCovered / journeyLength;
                    transform.position = Vector3.Lerp(pointB.position, pointA.position, fracJourney);
                    distanceCovered = (Time.time - startTime) * speed;
                    yield return null;
                }

                isMovingToPointB = true;
            }
        }
    }
}

