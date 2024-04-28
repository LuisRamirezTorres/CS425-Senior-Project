using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public Vector3 offset;
    private GameManager instance;
    public float smoothSpeed = 0.125f;


    void Start()
    {
        
        instance = GameManager.Instance;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        target = GameObject.FindGameObjectWithTag("Skeeball").transform;
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothPos;

        transform.LookAt(target);
        
    }
}
