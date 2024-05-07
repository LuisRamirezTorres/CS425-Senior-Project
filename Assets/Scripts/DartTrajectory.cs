using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrajectory : MonoBehaviour
{
    [SerializeField] 
    private LineRenderer lineRenderer;
    [SerializeField] 
    private Transform releasePosition;

    [SerializeField] 
    private Rigidbody dartRB;

    [SerializeField] 
    private Camera camera;
    
    [SerializeField] [field: Range(1, 100)]
    private float throwStrength = 10f;

    [field: Header("Display Controls")]
    
    [SerializeField] [field: Range(10, 100)]
    private int linePoints = 25;

    [SerializeField] [field: Range(0.01f, 0.25f)]
    private float timeBetweenPoints = 0.1f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        DrawProjection();
    }

    private void DrawProjection()
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = Mathf.CeilToInt(linePoints / timeBetweenPoints) + 1;
        Vector3 startPosition = releasePosition.position;
        Vector3 startVelocity = throwStrength * camera.transform.forward / dartRB.mass;

        int i = 0;
        lineRenderer.SetPosition(i, startPosition);
        for (float time = 0; time < linePoints; time += timeBetweenPoints)
        {
            i++;
            Vector3 point = startPosition + time * startVelocity;
            point.y = startPosition.x + startVelocity.x * time + (Physics.gravity.y / 2f * time * time);
            lineRenderer.SetPosition(i, point);
        }
    }
}
