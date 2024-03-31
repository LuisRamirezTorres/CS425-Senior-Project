using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DartboardScore : MonoBehaviour
{
    public GameObject floatingScorePrefab;
    public GameObject dartTip;
    public TMP_Text scoreText;
    public string scoreStr = "Score: ";
    public MeshCollider meshCollider;

    private int currentScore;

    private Mesh mesh;
    private Bounds bounds;
    private float colliderRadius;
    private Vector3 colliderCenter;
    private float angle;
    
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

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreStr + (currentScore/2).ToString();
    }

    public int GetScore()
    {
        return currentScore;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision detected: " + collider);

        // Get dart's pos after collision detected
        Vector3 dartPos = collider.gameObject.transform.position;
        Debug.Log("dartPos: " + dartPos);
        float dartPosY = dartPos.y;
        float dartPosZ = dartPos.z;
        
        // Get the dart's distance from the bullseye
        int distanceScore = CheckDistance(dartPos);
        
        // Get the dart's angle of the dartboard's collider from 0 to 360
        angle = GetDartAngle(dartPosY, dartPosZ);
        Debug.Log("Angle: " + angle);
        
        // Check the angle to return the correct score
        int angleScore = CheckAngle();
        
        // Temp score used to show pop up score when dart collides with the dartboard
        int tempScore = angleScore * distanceScore;
        currentScore += tempScore;
        ShowFloatingScore(dartPos, tempScore);
        
    }

    private float GetDartAngle(float dartPosY, float dartPosZ)
    {
        float degrees = Mathf.Atan2(dartPosY - colliderCenter.y, dartPosZ - colliderCenter.z) * 180 / Mathf.PI;
        degrees = (degrees + 360) % 360;
        return degrees;
    }

    private int CheckDistance(Vector3 dartPos)
    {
        var distanceScore = 0;
        
        float dartDistanceFromCenter = Vector3.Distance(dartPos, colliderCenter);
        Debug.Log("Dart distance from center: " + dartDistanceFromCenter);
        
    

        if (dartDistanceFromCenter is < 0.43f and > 0.37f)
            distanceScore = 3;
        else if (dartDistanceFromCenter is < 0.65f and > 0.60f)
            distanceScore = 2;
        else
            distanceScore = 1;
        
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

        Debug.Log("angleScore: " + angleScore);
        return angleScore;
    }

    void ShowFloatingScore(Vector3 dartPos, int tempScore)
    {
        var floatingText = Instantiate(floatingScorePrefab, dartPos, Camera.main.transform.rotation);
        floatingText.GetComponent<TMP_Text>().text = tempScore.ToString();
    }
}
