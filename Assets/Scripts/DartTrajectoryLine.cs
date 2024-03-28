using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrajectoryLine : MonoBehaviour
{
    [SerializeField] 
    private LineRenderer lineRenderer;

    [SerializeField] private float arc = -0.5f;

    [SerializeField, Min(3)] 
    private int lineSegments = 60;

    [SerializeField, Min(1)] 
    private float timeOfFlight = 5f;

    public void DrawLine(Vector3 startPoint, Vector3 startVelocity)
    {
        float timeStep = timeOfFlight / lineSegments;

        Vector3[] lineRendererPoints = CalculateTrajectory(startPoint, startVelocity, timeStep);

        lineRenderer.positionCount = lineSegments;
        lineRenderer.SetPositions(lineRendererPoints);
    }

    private Vector3[] CalculateTrajectory(Vector3 startPoint, Vector3 startVelocity, float timeStep)
    {
        Vector3[] lineRendererPoints = new Vector3[lineSegments];

        lineRendererPoints[0] = startPoint;
        for (int i = 0; i < lineSegments; i++)
        {
            float timeOffset = timeStep * i;
            Vector3 distance = startVelocity * timeOffset;
            Vector3 gravityOffset = Vector3.up * arc * Physics.gravity.y * timeOffset * timeOffset;
            Vector3 newPosition = startPoint + distance - gravityOffset;
            lineRendererPoints[i] = newPosition;
        }

        return lineRendererPoints;
    }
    
}
