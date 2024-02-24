using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBasketball : MonoBehaviour
{
    public GameObject ball;
    public Vector3 ballPos;
    public Vector3 highBallPos;
    public Rigidbody rb;
 
    // Start is called before the first frame update
    void Start()
    {
        ballPos = ball.transform.position;
        highBallPos = ball.transform.position + new Vector3(0,(float)(0.15) ,0);
    }

    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.B)) {
            rb.useGravity = false;
            GameObject clone = Instantiate(ball, ballPos, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            rb.useGravity = false;
            GameObject clone = Instantiate(ball, highBallPos, Quaternion.identity);
        }
    }
    void printTest()
    {
        Debug.Log("fn called");
    }
}
