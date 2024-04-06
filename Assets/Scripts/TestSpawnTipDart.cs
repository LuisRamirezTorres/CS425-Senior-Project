using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
public class TestSpawnTipDart : MonoBehaviour
{
    public SpawnTipDart spawnTipDart;
    public LeapProvider leapProvider;

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
        if (IsThumbExtended(_hand))
            Debug.Log("Thumb is Extended");
        if (IsIndexExtended(_hand))
            Debug.Log("Index finger is Extended");
        if (IsMiddleExtended(_hand))
            Debug.Log("Middle finger is Extended");
        if (IsRingExtended(_hand))
            Debug.Log("Ring finger is Extended");
        if (IsPinkyExtended(_hand))
            Debug.Log("Pinky finger is Extended");
        

    }

    bool IsThumbExtended(Hand _hand)
    {
        bool isThumbExtended;
        Finger _thumb = _hand.GetThumb();
        bool isThumb = _thumb.IsExtended;
        
        if (isThumb)
            isThumbExtended = true;
        else
            isThumbExtended = false;

        return isThumbExtended;
    }

    bool IsIndexExtended(Hand _hand)
    {
        bool isIndexExtended;
        Finger _index = _hand.GetIndex();
        bool isIndex = _index.IsExtended;

        if (isIndex)
            isIndexExtended = true;
        else
            isIndexExtended = false;

        return isIndexExtended;
    }

    bool IsMiddleExtended(Hand _hand)
    {
        bool isMiddleExtended;
        Finger _middle = _hand.GetMiddle();
        bool isMiddle = _middle.IsExtended;
        
        if (isMiddle)
            isMiddleExtended = true;
        else
            isMiddleExtended = false;

        return isMiddleExtended;
    }

    bool IsRingExtended(Hand _hand)
    {
        bool isRingExtended;
        Finger _ring = _hand.GetRing();
        bool isRing = _ring.IsExtended;
        
        if (isRing)
            isRingExtended = true;
        else
            isRingExtended = false;

        return isRingExtended;
    }

    bool IsPinkyExtended(Hand _hand)
    {
        bool isPinkyExtended;
        Finger _pinky = _hand.GetPinky();
        bool isPinky = _pinky.IsExtended;
        
        if (isPinky)
            isPinkyExtended = true;
        else
            isPinkyExtended = false;

        return isPinkyExtended;
    }
}
