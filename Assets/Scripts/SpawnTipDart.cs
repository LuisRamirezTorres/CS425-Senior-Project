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
        
        // To respawn a ball, the left hand must be open, then unextended.
        // The current ball must also not exist
        if (IsExtended(_hand) && !isInstantiated)
        {
            Debug.Log("Thumb is extended");
            dartCount.DecreaseDarts();
            SpawnDart();
            isInstantiated = true;
        }

        if (!IsExtended(_hand))
        {
            isInstantiated = false;
        }
    }

    public void SpawnDart()
    {
        dartInstance = Instantiate(dartPrefab, dartPos, dartOrientation);
        throwCount++;
    }

    bool IsExtended(Hand _hand)
    {
        bool isHandOpen;
        Finger _thumb = _hand.GetThumb();
        Finger _index = _hand.GetIndex();
        Finger _middle = _hand.GetMiddle();
        Finger _ring = _hand.GetRing();
        Finger _pinky = _hand.GetPinky();

        bool isThumb = _thumb.IsExtended;
        bool isIndex = _index.IsExtended;
        bool isMiddle = _middle.IsExtended;
        bool isRing = _ring.IsExtended;
        bool isPinky = _pinky.IsExtended;

        if (isThumb && isIndex && isMiddle && isRing && isPinky)
            isHandOpen = true;
        else
            isHandOpen = false;

        return isHandOpen;
    }
    
}
