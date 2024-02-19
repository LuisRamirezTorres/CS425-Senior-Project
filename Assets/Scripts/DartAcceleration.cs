using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is taken from BasketballAcceleration by Emanuel
public class DartAcceleration : MonoBehaviour
{
    public Rigidbody dart_rb;
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
        Debug.Log(dart_rb.velocity);
    }
    void Accelerate()
    {
        this.PrintVelocity();
        Vector3 added_vel = new Vector3(x_added_speed, y_added_speed, 0);
        dart_rb.velocity = dart_rb.velocity + added_vel;
        this.PrintVelocity();
    }
}