using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDart : MonoBehaviour
{
    [SerializeField] 
    private Vector3 crosshairPos;

    public GameObject dart;
    public float offset = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//        transform.position = dart.transform.position + dart.transform.forward;
        dart.transform.position = transform.position + transform.forward;
        crosshairPos.z = offset;
//        transform.position = Camera.main.ScreenToWorldPoint(crosshairPos);
    }
}
