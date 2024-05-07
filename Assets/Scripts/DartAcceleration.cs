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
    private float randomX1;
    
    [SerializeField]
    private float randomX2;
    
    [SerializeField]
    private float randomY1;
    
    [SerializeField]
    private float randomY2;

    [SerializeField] 
    private float turn = 2.0f;

    public AudioSource audioSource;
    public AudioClip sfx;

    public GameObject spawnDart;
    
    void PrintVelocity()
    {
        Debug.Log("Dart Velocity: " + dartRB.velocity);
    }
    void Accelerate()
    {
        audioSource.clip = sfx;
        audioSource.Play();
        
        /*Vector3 addedVel = new Vector3(x_added_speed, y_added_speed, 0);*/
        Vector3 addedVel = new Vector3(Random.Range(randomX1, randomX2), Random.Range(randomY1, randomY2), 0);
        dartRB.velocity += addedVel;
//        interactionBehaviour.AddLinearAcceleration(addedVel);
//        dartRB.AddForce(dartBoardRB.transform.forward);
//        dartRB.velocity = dartRB.velocity + addedVel;
//        dartRB.AddTorque(transform.forward * 1 * turn);
        PrintVelocity();
        
        spawnDart.SetActive(true);
    }
}