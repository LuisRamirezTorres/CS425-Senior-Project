using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextSkeeball : MonoBehaviour
{

    public float destroyTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }

    
}
