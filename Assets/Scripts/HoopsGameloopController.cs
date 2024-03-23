using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
public class HoopsGameloopController : MonoBehaviour
{
    // Start is called before the first frame update

    public LeapProvider leapProvider;
    public DetectHoopsScore gameloop;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        Hand _rightHand = frame.GetHand(Chirality.Right);


        //When we have a valid left hand, we can begin searching for more Hand information
        if (_leftHand != null && _rightHand != null)
        {
            OnUpdateHands(_leftHand, _rightHand);
        }
    }
    void OnUpdateHands(Hand left_hand,Hand right_hand)
    {
        Finger _thumb = left_hand.GetThumb();

        Finger right_thumb = right_hand.GetThumb();
        if (_thumb.IsExtended && right_thumb.IsExtended)
        {
            Debug.Log("Extended thumbs");
            gameloop.SendMessage("restart");
        }

    }


}
