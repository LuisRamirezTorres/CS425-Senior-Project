using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

// If pinch strength < x, GraspEnd()
public class DartPinchStrength : MonoBehaviour
{
    public LeapProvider leapProvider;

    public Vector3 dartPos;

    public GameObject dart;

    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        dartPos = dart.transform.position;
        rb = GetComponent<Rigidbody>();
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
        Hand _rightHand = frame.GetHand(Chirality.Right);

        //When we have a valid left hand, we can begin searching for more Hand information
        if(_rightHand != null)
        {
            OnUpdateHand(_rightHand);
        }
    }

    void OnUpdateHand(Hand _hand)
    {
        Finger _index = _hand.GetIndex();
        Finger _thumb = _hand.GetThumb();
        
        float _pinchStrength = _hand.PinchStrength;
        Debug.Log("Pinch Strength:" + _pinchStrength);

        if (_pinchStrength > .50)
        {
            rb.isKinematic = true;
            dart.transform.position = _thumb.TipPosition;
        }
        else
        {
            rb.isKinematic = false;
        }
        
    }
}    

