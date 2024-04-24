using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartShowLine : MonoBehaviour
{
    [SerializeField]
    private Transform dart;
    
    [SerializeField] 
    private DartTrajectoryLine dartTrajectoryLine;

    // Update is called once per frame
    void Update()
    {
        dartTrajectoryLine.DrawLine(dart.position, -transform.forward);
    }
}
