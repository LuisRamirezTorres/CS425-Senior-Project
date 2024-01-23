using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBowlingBall : MonoBehaviour
{
    public GameObject bowlingBall;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ballPosition = new Vector3(0.482f, 0.711f, 19.959f);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bowlingBall, ballPosition, Quaternion.identity);
            // Quaternion.Euler(158.4f, 2.020f, -85.28f
        }
        
    }
}
