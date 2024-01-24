using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using static Leap.Unity.Detector;

public class SpawnBall : MonoBehaviour
{
    public GameObject ball;
    public LeapProvider leapProvider;
    public Hand leftHand;
    public Finger thumb;
//    public Finger.FingerType fingerType;
//    public PointingType pointingType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftHand = Hands.Provider.GetHand(Chirality.Left);
        thumb = leftHand.GetThumb();
        Vector3 ballPosition = new Vector3(0.482f, 0.711f, 19.959f);
       // if (fingerType == Finger.FingerType.TYPE_THUMB && pointingType == PointingType.RelativeToWorld)
        if (thumb.IsExtended)
        {
            Instantiate(ball, ballPosition, Quaternion.identity);
        }
        
    }
}
