using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test script to send ball forward and monitor interaction with pins
// Taken from Unity https://docs.unity3d.com/ScriptReference/Transform-forward.html
public class BallForward : MonoBehaviour
{
    public GameObject ball;
    public GameObject pins;
    public Vector3 pos;
    public Vector3 pinPos;
    Rigidbody _ball;
    float _speed;
    private int _count;
    
    void Start()
    {
//        pos = new Vector3(0.784f, -0.509f, 7.078f);
        pos = ball.transform.position;
        pinPos = pins.transform.position;
        _ball = GetComponent<Rigidbody>();
        _speed = 10.0f;
        _count = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _ball.velocity = transform.forward * _speed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Invoke("SpawnBall", 2);
            Destroy(ball, 2);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Invoke("SpawnPins", 2);
//            Destroy(pins, 2);
        }

    }

    void SpawnBall()
    {
        Instantiate(ball, pos, Quaternion.identity);
    }
    
    void SpawnPins()
    {
        Instantiate(pins, pinPos, Quaternion.identity);
    }
}
