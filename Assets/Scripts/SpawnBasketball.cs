using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBasketball : MonoBehaviour
{
    public GameObject ball;
    public Vector3 ballPos;
    public Vector3 highBallPos;
    public Rigidbody rb;
    private const float SPAWN_COOLDOWN = 0.9f;
    private float cooldown = SPAWN_COOLDOWN;
    private bool spawning = false;
 
    // Start is called before the first frame update
    void Start()
    {
        //ballPos = ball.transform.position;
        //ballPos -= new Vector3(0, 0, 3.22f);
        ballPos = new Vector3(1.74f, 1.48f, -1.25f);
        highBallPos = ball.transform.position + new Vector3(0,(float)(0.15) ,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.spawning &&  cooldown <= 0)
        {
            this.spawning = false;
            this.cooldown = SPAWN_COOLDOWN;
            rb.useGravity = false;
            GameObject clone = Instantiate(ball, ballPos, Quaternion.identity);
        }
        else if (this.spawning)
        {
            this.cooldown -= Time.deltaTime;
        }
        {
            
        }

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

    void spawn()
    {
        if (!spawning)
        {

            spawning = true;
        }

    }
}
