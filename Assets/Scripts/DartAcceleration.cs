using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is taken from BasketballAcceleration by Emanuel
public class DartAcceleration : MonoBehaviour
{
    public Rigidbody dartRB;
    public Rigidbody dartBoardRB;
    public float x_added_speed;
    public float y_added_speed;
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
        Debug.Log(dartRB.velocity);
    }
    void Accelerate()
    {
        this.PrintVelocity();
        Vector3 addedVel = new Vector3(x_added_speed, y_added_speed, 0);
        dartRB.AddForce(dartBoardRB.transform.forward);
        dartRB.velocity = dartRB.velocity + addedVel;
        this.PrintVelocity();
    }
}