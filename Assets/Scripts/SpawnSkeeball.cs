using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;
using Unity.VisualScripting;


public class SpawnSkeeball : MonoBehaviour
{

    public GameObject skeeball;
    public Rigidbody rigidbody;
    private GameManager instance;


    // Start is called before the first frame update
    void Start()
    {


        instance = GameManager.Instance;


    }

    // Update is called once per frame
    void Update()
    {

        if (!GameObject.FindGameObjectWithTag("Skeeball") && instance.getBallCount() > 0)
        {
   
            GameObject newBall = Instantiate(skeeball, this.transform.position, Quaternion.identity);
            rigidbody = newBall.GetComponent<Rigidbody>();
            rigidbody.useGravity = false;

        }

    }
}


