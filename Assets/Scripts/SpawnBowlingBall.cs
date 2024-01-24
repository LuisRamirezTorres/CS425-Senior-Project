using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using static Leap.Unity.Detector;

public class SpawnBowlingBall : MonoBehaviour
{
    public GameObject ball;
    public LeapProvider leapProvider;
    public bool isInstantiated;
    public int extCount;
//    public Hand leftHand;
//    public Finger thumb;
//    public Finger.FingerType fingerType;
//    public PointingType pointingType;
    // Start is called before the first frame update
    void Start()
    {
        
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
        extCount = 0;
        Finger _thumb = _hand.GetThumb();
        Vector3 ballPosition = new Vector3(0.482f, 0.711f, 19.959f);
        // if (fingerType == Finger.FingerType.TYPE_THUMB && pointingType == PointingType.RelativeToWorld)
        if (_thumb.IsExtended && !isInstantiated)
        {
            Instantiate(ball, ballPosition, Quaternion.identity);
            isInstantiated = true;
        }

        if (!_thumb.IsExtended)
        {
            isInstantiated = false;
        }
    }
    
}