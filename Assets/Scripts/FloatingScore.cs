using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScore : MonoBehaviour
{
    public float destroyTime = 2f;

    public Vector3 offSet = new Vector3(0, 0, 6);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    
}
