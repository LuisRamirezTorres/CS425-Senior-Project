using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCollision : MonoBehaviour
{
    public float lifetime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " starts colliding");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " is colliding");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " stops colliding");
        Destroy(collision.gameObject, lifetime);
    }
}
