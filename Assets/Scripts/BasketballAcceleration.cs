using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballAcceleration : MonoBehaviour
{
    public Rigidbody basketball_rb;
    public int x_added_speed;
    public int y_added_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void printVelocity()
    {
        Debug.Log(basketball_rb.velocity);
    }
    void accelerate()
    {
        this.printVelocity();
        Vector3 added_vel = new Vector3(x_added_speed, y_added_speed, 0);
        basketball_rb.velocity = basketball_rb.velocity + added_vel;
        this.printVelocity();
    }
}
