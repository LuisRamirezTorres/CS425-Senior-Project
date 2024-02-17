using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStick : MonoBehaviour
{
    private Rigidbody rb;

    private bool targetToHit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (targetToHit)
            return;
        else
            targetToHit = true;

        rb.isKinematic = true;
        
        transform.SetParent(collision.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
