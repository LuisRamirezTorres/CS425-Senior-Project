using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeeballAcceleration : MonoBehaviour
{
    public Rigidbody skeeball;
    public int xSpeed;
    public int ySpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void accelerateSkeeball()
    {
        Vector3 velocity = new Vector3(xSpeed, ySpeed, 0);
        skeeball.velocity += velocity;
    }
}
