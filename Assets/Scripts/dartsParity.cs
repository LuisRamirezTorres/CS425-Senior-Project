using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using static Leap.Unity.Detector;
using UnityEngine.SceneManagement;


public class dartsParity : MonoBehaviour
{

    public LeapProvider leapProvider;

    // Start is called before the first frame update

    private bool extendCheck;



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
            OnUpdateHand(_leftHand, "left");
            // OnUpdateHand(_rightHand);
        }

        if (_rightHand != null)
        {

            OnUpdateHand(_rightHand, "right");
        }
    }

    void OnUpdateHand(Hand _hand, string side)
    {



        if (IsExtended(_hand) && !extendCheck && side == "left")
        {
            Debug.Log("Right Hand Raised");
           SceneManager.LoadScene("Darts");
            extendCheck = true;
        }


        if (IsExtended(_hand) && !extendCheck && side == "right")
        {
            Debug.Log("Left Hand Raised");
            SceneManager.LoadScene("DartsLeftHand");
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
