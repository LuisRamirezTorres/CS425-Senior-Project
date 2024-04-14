using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public Vector3 offset;
    private GameManager instance;


    void Start()
    {
        
        instance = GameManager.Instance;


    }

    // Update is called once per frame
    void Update()
    {

        target = GameObject.FindGameObjectWithTag("Skeeball").transform;
        transform.position = target.position + offset;
        
    }
}
