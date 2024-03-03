using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPins : MonoBehaviour
{
    private Vector3 _lastBallPosition;
    private int _throwCount;
    public GameObject ball;
    public GameObject pins;
    public bool isInstatiated;
   
    void Start()
    {
        _throwCount = 0;
        // Get z pos of bowling ball
        _lastBallPosition.z = ball.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        
        // Check if z pos of bowling ball has been thrown, then spawn new set of pins after 7 sec
        if (_lastBallPosition.z < 4.0f)
        {
            Vector3 pinPosition = new Vector3(0.753f, -0.418f, 3.381f);
            Instantiate(pins, pinPosition, Quaternion.identity);
            //Invoke("InstantiatePins", 1.0f);
        }
    }

    void InstantiatePins()
    {
        Vector3 pinPosition = new Vector3(0.753f, -0.418f, 3.381f);
        Instantiate(pins, pinPosition, Quaternion.identity);
    }
}
