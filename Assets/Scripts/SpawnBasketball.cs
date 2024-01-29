using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBasketball : MonoBehaviour
{
    public GameObject ball;
    public Vector3 ballPos;
    public Rigidbody rb;
 
    // Start is called before the first frame update
    void Start()
    {
        ballPos = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.B)) {
            rb.useGravity = false;
            Debug.Log("B pressed");
            GameObject clone = Instantiate(ball, ballPos, Quaternion.identity);
        }
    }
}
