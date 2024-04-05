using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;

// This script is taken from BasketballAcceleration by Emanuel
public class DartAcceleration : MonoBehaviour
{
    public Rigidbody dartRB;
    public Rigidbody dartBoardRB;
    public float x_added_speed;
    public float y_added_speed;

    [SerializeField] 
    private float turn = 2.0f;

    /*[SerializeField] 
    private InteractionBehaviour interactionBehaviour;*/
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PrintVelocity()
    {
        Debug.Log("Dart Velocity: " + dartRB.velocity);
    }
    void Accelerate()
    {
        Vector3 addedVel = new Vector3(x_added_speed, y_added_speed, 0);
//        interactionBehaviour.AddLinearAcceleration(addedVel);
        dartRB.AddForce(dartBoardRB.transform.forward);
        dartRB.velocity = dartRB.velocity + addedVel;
        dartRB.AddTorque(transform.forward * 1 * turn);
        PrintVelocity();
    }
}