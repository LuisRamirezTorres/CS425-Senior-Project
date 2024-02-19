using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDart : MonoBehaviour
{
    public GameObject dart;
    public Vector3 dartPos;
    
    // Start is called before the first frame update
    void Start()
    {
        dartPos = dart.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTipDart()
    {
        Debug.Log("SpawnTipDart");
        Instantiate(dart, dartPos, Quaternion.identity);
    }
}
