using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;

public class DartPinchStrength : MonoBehaviour
{
    public LeapProvider leapProvider;
    
    public InteractionController interactionController;

    private bool isPinching;

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
        Hand _rightHand = frame.GetHand(Chirality.Right);

        //When we have a valid left hand, we can begin searching for more Hand information
        if(_rightHand != null)
        {
            OnUpdateHand(_rightHand);
        }
    }

    void OnUpdateHand(Hand _hand)
    {
        float pinchStrength = _hand.PinchStrength;
        Debug.Log("Pinch Strength:" + pinchStrength);

        if (pinchStrength > 0.5 && !isPinching)
        {
            isPinching = true;
            /*interactionBehaviour.EndGrasp(interactionController);*/

        }
        else if (pinchStrength < 0.4 && isPinching)
        {
            isPinching = false;
            interactionController.ReleaseGrasp();
        }
        
    }
}    

