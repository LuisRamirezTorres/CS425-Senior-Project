using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartShowLine : MonoBehaviour
{
    [SerializeField]
    private Transform capsuleHand;
    
    [SerializeField] 
    private DartTrajectoryLine dartTrajectoryLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dartTrajectoryLine.DrawLine(capsuleHand.position, -transform.forward);
    }
}
