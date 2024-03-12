using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartboardScore : MonoBehaviour
{
    public GameObject dartBoard;
    public GameObject dartTip;

    private int score;
    private int[] angleArr = new int[360];
    private Transform dartPos;
    
    private SphereCollider dartBoardCollider;
    
    private float colliderRadius;
    private float angle;
    
    private Vector3 colliderCenter;
    
    // Start is called before the first frame update
    void Start()
    {
        dartBoardCollider = GetComponent<SphereCollider>();
        colliderRadius = GetComponent<SphereCollider>().radius;
        colliderCenter = GetComponent<SphereCollider>().center;

        for (var i = 0; i < 360; i++)
        {
            angleArr[i] = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        angle = Mathf.Atan2(colliderCenter.x, colliderCenter.y);
        CheckAngle();

        
    }

    private void CheckDistance()
    {
        
    }

    private void CheckAngle()
    {
        if (angle is < 81.0f and > 63.0f)
            score += 1;
        if (angle is < 63.0f and > 45.0f)
            score += 18;
        if (angle is < 45.0f and > 27.0f)
            score += 4;
        if (angle is < 27.0f and > 9.0f)
            score += 13;
        
        if (angle is < 351.0f and > 9.0f)
            score += 6;
        if (angle is < 351.0f and > 333.0f)
            score += 10;
        if (angle is < 333.0f and > 315.0f)
            score += 15;
        if (angle is < 315.0f and > 297.0f)
            score += 2;
        
        if (angle is < 297.0f and > 279.0f)
            score += 17;
        if (angle is < 279.0f and > 261.0f)
            score += 3;
        if (angle is < 261.0f and > 243.0f)
            score += 19;
        if (angle is < 243.0f and > 225.0f)
            score += 7;
        
        if (angle is < 225.0f and > 207.0f)
            score += 16;
        if (angle is < 207.0f and > 189.0f)
            score += 8;
        if (angle is < 189.0f and > 171.0f)
            score += 11;
        if (angle is < 171.0f and > 153.0f)
            score += 14;
        
        if (angle is < 153.0f and > 135.0f)
            score += 9;
        if (angle is < 135.0f and > 117.0f)
            score += 12;
        if (angle is < 117.0f and > 99.0f)
            score += 5;
        if (angle is < 99.0f and > 81.0f)
            score += 20;
    
    }
}
