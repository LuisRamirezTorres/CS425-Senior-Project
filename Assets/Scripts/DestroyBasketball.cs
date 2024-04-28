using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBasketball : MonoBehaviour
{
    public int destruction_time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void delayed_destroy()
    {
        Object.Destroy(gameObject, destruction_time);
    }
}
