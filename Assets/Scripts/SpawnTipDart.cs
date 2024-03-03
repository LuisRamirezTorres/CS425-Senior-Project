using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using static Leap.Unity.Detector;

// Template taken from Ultraleap 
// https://docs.ultraleap.com/xr-and-tabletop/xr/unity/plugin/features/scripting-fundamentals.html
public class SpawnTipDart : MonoBehaviour
{
    public GameObject dartPrefab;
    GameObject dartInstance;
    public Vector3 dartPos;
    public Quaternion dartOrientation;
    
    public LeapProvider leapProvider;
    public DartCount dartCount;
    
    public bool isInstantiated;
    public int throwCount;
    
    void Start()
    {
        throwCount = 0;
        dartPos = dartPrefab.transform.position;  // Get current dart pos
        dartOrientation = dartPrefab.transform.rotation; // Get current dart orientation
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
        // Use a helpful utility function to get the first hand that matches the Chirality
        Hand _leftHand = frame.GetHand(Chirality.Left);

        // When we have a valid left hand, we can begin searching for more Hand information
        if(_leftHand != null)
        {
            OnUpdateHand(_leftHand);
        }
    }

    void OnUpdateHand(Hand _hand)
    {
        Finger _thumb = _hand.GetThumb();
        
        // To respawn a ball, the left thumb must be extended, then unextended.
        // The current ball must also not exist
        if (_thumb.IsExtended && !isInstantiated)
        {
            Debug.Log("Thumb is extended");
            dartCount.DecreaseDarts();
            SpawnDart();
            isInstantiated = true;
        }

        if (!_thumb.IsExtended)
        {
            isInstantiated = false;
        }
    }

    public void SpawnDart()
    {
        dartInstance = Instantiate(dartPrefab, dartPos, dartOrientation);
        throwCount++;
    }
    
}
