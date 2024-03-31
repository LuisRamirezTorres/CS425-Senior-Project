using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowBall : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    private GameManager instance;

    // Update is called once per frame

    void Start()
    {
        instance = GameManager.Instance;
    }
    void Update()
    {

        target = GameObject.FindGameObjectWithTag("Skeeball").transform;
        transform.position = target.position + offset;
        

    }


}
