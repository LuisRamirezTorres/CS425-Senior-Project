using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DartboardScore : MonoBehaviour
{
    public GameObject dartBoard;
    public GameObject dartTip;
    public TMP_Text scoreText;
    public string scoreStr = "Score: ";

    private int currentScore;

    private Mesh mesh;
    Bounds bounds;
    private float colliderRadius;
    private Vector3 colliderCenter;
    private float angle;

    public MeshCollider meshCollider;
    
//    public SphereCollider dartBoardCollider;
//    private float colliderRadius;
//    private Vector3 colliderCenter;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        scoreText.text = scoreStr + currentScore.ToString();

        meshCollider = GetComponent<MeshCollider>();
        colliderCenter = meshCollider.bounds.center;
        colliderRadius = meshCollider.bounds.extents.y;
        
        Debug.Log("colliderCenter: " + colliderCenter);
        Debug.Log("colliderRadius: " + colliderRadius);
//        mesh = GetComponent<MeshFilter>().mesh;
//        bounds = mesh.bounds;
//        colliderRadius = bounds.extents.x;
//        colliderCenter = bounds.center;

        /*dartBoardCollider = GetComponent<SphereCollider>();
        colliderRadius = GetComponent<SphereCollider>().radius;
        colliderCenter = GetComponent<SphereCollider>().center;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision detected");

        Vector3 dartPos = dartTip.transform.position;
        Debug.Log("dartPos: " + dartPos);
        float dartPosY = dartPos.y;
        float dartPosZ = dartPos.z;
        
//        distanceScore = CheckDistance(dartPosY, dartPosZ);
        var distanceScore = CheckDistance(dartPos);
        angle = GetDartAngle(dartPosY, dartPosZ);
        Debug.Log("Angle: " + angle);
        var angleScore = CheckAngle();
        currentScore += (distanceScore * angleScore);
        scoreText.text = scoreStr + currentScore.ToString();
        
    }

    private float GetDartAngle(float dartPosY, float dartPosZ)
    {
        float degrees = Mathf.Atan2(dartPosY - colliderCenter.y, dartPosZ - colliderCenter.z) * 180 / Mathf.PI;
        degrees = (degrees + 360) % 360;
    //    return degrees;
        /*if (degrees > 180)
            degrees = 270 + degrees;
        else
            degrees = 90 + degrees;*/
        return degrees;
    }

    private int CheckDistance(Vector3 dartPos)
    {
        var distanceScore = 0;
        float dartDistanceFromCenter = Vector3.Distance(dartPos, colliderCenter);
        float halfRadius = colliderRadius * 0.5f;

        if (dartDistanceFromCenter == colliderRadius)
            distanceScore = 2;
        else if (dartDistanceFromCenter is < 0.3507f and > 0.3206f)
            distanceScore = 3;
        else
            distanceScore = 1;
        
        /*if (dartPosY == (0.5f * colliderRadius) || (dartPosZ == (0.5f * colliderRadius)))
        {
            distanceScore = 3;
        }
        
        if (dartPosY == colliderRadius || dartPosZ == colliderRadius)
        {
            distanceScore = 2;
        }*/
        Debug.Log("distanceScore: " + distanceScore);
        return distanceScore;
    }

    private int CheckAngle()
    {
        var angleScore = 0;
        
        if (angle is < 351.0f and > 9.0f)
            angleScore = 11;
        if (angle is < 27.0f and > 9.0f)
            angleScore = 14;
        if (angle is < 45.0f and > 27.0f)
            angleScore = 9;
        if (angle is < 63.0f and > 45.0f)
            angleScore = 12;
        
        if (angle is < 81.0f and > 63.0f)
            angleScore = 5;
        if (angle is < 99.0f and > 81.0f)
            angleScore = 20;
        if (angle is < 117.0f and > 99.0f)
            angleScore = 1;
        if (angle is < 135.0f and > 117.0f)
            angleScore = 18;
        
        if (angle is < 153.0f and > 135.0f)
            angleScore = 4;
        if (angle is < 171.0f and > 153.0f)
            angleScore = 13;
        if (angle is < 189.0f and > 171.0f)
            angleScore = 6;
        if (angle is < 207.0f and > 189.0f)
            angleScore = 10;
        
        if (angle is < 225.0f and > 207.0f)
            angleScore = 15;
        if (angle is < 243.0f and > 225.0f)
            angleScore = 2;
        if (angle is < 261.0f and > 243.0f)
            angleScore = 17;
        if (angle is < 279.0f and > 261.0f)
            angleScore = 3;
        
        if (angle is < 297.0f and > 279.0f)
            angleScore = 19;
        if (angle is < 315.0f and > 297.0f)
            angleScore = 7;
        if (angle is < 333.0f and > 315.0f)
            angleScore = 16;
        if (angle is < 351.0f and > 333.0f)
            angleScore = 8;
        
        /*if (angle is < 81.0f and > 63.0f)
            angleScore = 1;
        if (angle is < 63.0f and > 45.0f)
            angleScore = 18;
        if (angle is < 45.0f and > 27.0f)
            angleScore = 4;
        if (angle is < 27.0f and > 9.0f)
            angleScore = 13;
        
        if (angle is < 351.0f and > 9.0f)
            angleScore = 6;
        if (angle is < 351.0f and > 333.0f)
            angleScore = 10;
        if (angle is < 333.0f and > 315.0f)
            angleScore = 15;
        if (angle is < 315.0f and > 297.0f)
            angleScore = 2;
        
        if (angle is < 297.0f and > 279.0f)
            angleScore = 17;
        if (angle is < 279.0f and > 261.0f)
            angleScore = 3;
        if (angle is < 261.0f and > 243.0f)
            angleScore = 19;
        if (angle is < 243.0f and > 225.0f)
            angleScore = 7;
        
        if (angle is < 225.0f and > 207.0f)
            angleScore = 16;
        if (angle is < 207.0f and > 189.0f)
            angleScore = 8;
        if (angle is < 189.0f and > 171.0f)
            angleScore = 11;
        if (angle is < 171.0f and > 153.0f)
            angleScore = 14;
        
        if (angle is < 153.0f and > 135.0f)
            angleScore = 9;
        if (angle is < 135.0f and > 117.0f)
            angleScore = 12;
        if (angle is < 117.0f and > 99.0f)
            angleScore = 5;
        if (angle is < 99.0f and > 81.0f)
            angleScore = 20;*/

        Debug.Log("angleScore: " + angleScore);
        return angleScore;
    }
}
