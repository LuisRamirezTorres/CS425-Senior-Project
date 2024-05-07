using System;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using UnityEngine;

public class GesturesGameOver : MonoBehaviour
{
    public LeapProvider leapProvider;
    
    [SerializeField]
    private GameOver gameOver;
    
    private bool isExtended;
    
    public void Setup()
    {
        gameObject.SetActive(true);
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
        if(_leftHand != null && _rightHand != null)
        {
            OnUpdateHand(_leftHand);
            OnUpdateHand(_rightHand);
        }
    }
    
    void OnUpdateHand(Hand _hand)
    {
        
        // To respawn a dart, the left hand must be open, then unopened.
        if (IsThumbsUp(_hand) && !isExtended)
        {
            gameOver.NewGame();
        }

        if (!IsThumbsUp(_hand))
        {
            isExtended = false;
        }
    }

    bool IsThumbsUp(Hand _hand)
    {
        bool isThumbsUp;
        
        Finger _thumb = _hand.GetThumb();
        bool isThumb = _thumb.IsExtended;
        
        if (isThumb)
            isThumbsUp = true;
        else
            isThumbsUp = false;

        return isThumbsUp;
    }
}
