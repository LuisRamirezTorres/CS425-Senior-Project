using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartShowLine : MonoBehaviour
{
    [SerializeField]
    private Transform dart;
    
    [SerializeField] 
    private DartTrajectoryLine dartTrajectoryLine;

    private bool isLine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isLine = !isLine;
            if (isLine)
                dartTrajectoryLine.lineRenderer.enabled = false;
            else
                dartTrajectoryLine.lineRenderer.enabled = true;
        }


        dartTrajectoryLine.DrawLine(dart.position, -transform.forward);
    }
}
