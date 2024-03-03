using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using static Leap.Unity.Detector;

// Template taken from Ultraleap 
// https://docs.ultraleap.com/xr-and-tabletop/xr/unity/plugin/features/scripting-fundamentals.html
public class SpawnBowlingBall : MonoBehaviour
{
    public GameObject ball;
    public GameObject pins;
    public Vector3 ballPos;
    public Vector3 pinPos;
    public LeapProvider leapProvider;
    public bool isInstantiated;
    public int throwCount;
    
//    public Hand leftHand;
//    public Finger thumb;
//    public Finger.FingerType fingerType;
//    public PointingType pointingType;
    // Start is called before the first frame update
    void Start()
    {
        throwCount = 0;
        ballPos = ball.transform.position;  // Get current ball pos
        pinPos = pins.transform.position;   // Get current pins pos
    }

    void Update()
    {
        // If the ball has reached the end of the lane (pinPos) and has been thrown twice
        // Respawn the pins
        if (ballPos == pinPos && throwCount == 2)
        {
            SpawnPins();
            throwCount = 0;
        }
    }

    private void OnEnable()
    {
        leapProvider.OnUpdateFrame += OnUpdateFrame;
    }
    private void OnDisable()
    {
        leapProvider.OnUpdateFrame -= OnUpdateFrame;
    }
    
    void OnUpdateFrame(Frame frame)
    {
        //Use a helpful utility function to get the first hand that matches the Chirality
        Hand _leftHand = frame.GetHand(Chirality.Left);

        //When we have a valid left hand, we can begin searching for more Hand information
        if(_leftHand != null)
        {
            OnUpdateHand(_leftHand);
        }
    }

    void OnUpdateHand(Hand _hand)
    {
        Finger _thumb = _hand.GetThumb();
 //       Vector3 ballPosition = new Vector3(0.482f, 0.711f, 19.959f);
        // if (fingerType == Finger.FingerType.TYPE_THUMB && pointingType == PointingType.RelativeToWorld)
        
        // To respawn a ball, the left thumb must be extended, then unextended.
        // The current ball must also not exist
        if (_thumb.IsExtended && !isInstantiated && !ball)
        {
            SpawnBall();
            isInstantiated = true;
        }

        if (!_thumb.IsExtended)
        {
            isInstantiated = false;
        }
    }

    public void SpawnBall()
    {
        Instantiate(ball, ballPos, Quaternion.identity);
        throwCount++;
    }

    public void SpawnPins()
    {
        Instantiate(pins, pinPos, Quaternion.identity);
        throwCount = 0;
    }
    
}