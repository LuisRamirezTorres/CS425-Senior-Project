using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class UltraLeapCameraMovement : MonoBehaviour
{
    private Controller _controller;
    public LeapProvider leapProvider;
    public Hand hand;
    void Start()
    {
        _controller = new Controller();
    }

    // Update is called once per frame
    void Update()
    {
        Hand _specificHand = Hands.Provider.GetHand(Chirality.Left);
        List<Hand> _allHands = Hands.Provider.CurrentFrame.Hands;
        Vector3 handLeft = hand.PalmPosition;
//        transform.Rotate(0, Vector3.up, handLeft);
        transform.rotation = Quaternion.Euler(handLeft);
    }

    void MoveCamera()
    {

    }
    
    
}
