using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;
using Unity.VisualScripting;
using UnityEngine;

public class ToggleGravity : MonoBehaviour
{
    public Rigidbody rig;
    public LeapProvider leapProvider;
//    public Hand hand;
    public InteractionBehaviour interactionBehaviour;

    void Start() {
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // if (interactionBehaviour.isGrasped)
        // {
        //     rig.useGravity = true;
        // }
        // else
        // {
        //     rig.useGravity = false;
        // }
        // bool isPinching = _hand.IsPinching();
        // if(rig == isPinching)
        // {
        //     rig.useGravity = true;
        // }
        // else
        // {
        //     rig.useGravity = false;
        // }
    }

    public void GravityOn() {
        rig.useGravity = true;
    }
    
    public void GravityOff() {
        rig.useGravity = false;
    }
}
