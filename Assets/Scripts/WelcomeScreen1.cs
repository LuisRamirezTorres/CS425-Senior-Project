using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using static Leap.Unity.Detector;
using UnityEngine.SceneManagement;

public class WelcomeScreen1 : MonoBehaviour
{


    public LeapProvider leapProvider;


    public void ChangeWelcome()
    {
        SceneManager.LoadScene(1);
    }


    private bool extendCheck;

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
        // Use a helpful utility function to get the first hand that matches the Chirality
        Hand _leftHand = frame.GetHand(Chirality.Left);
        Hand _rightHand = frame.GetHand(Chirality.Right);

        // When we have a valid left hand, we can begin searching for more Hand information
        if (_leftHand != null /*|| _rightHand != null*/)
        {
            OnUpdateHand(_leftHand);
            OnUpdateHand(_rightHand);
        }
    }

    void OnUpdateHand(Hand _hand)
    {
        

        
        if (IsExtended(_hand) && !extendCheck)
        {
            Debug.Log("All fingers are extended");
            ChangeWelcome();
            extendCheck = true;
        }

        if (!IsExtended(_hand))
        {
            extendCheck = false;
        }
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