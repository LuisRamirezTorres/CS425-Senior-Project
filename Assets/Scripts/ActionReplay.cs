using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script taken from https://www.youtube.com/watch?v=R8RinJDzhf8 */

public class ActionReplay : MonoBehaviour
{
    private List<RecordReplay> recordReplays = new List<RecordReplay>();
    private bool isInReplayMode;
    private Rigidbody rb;
    private float currentReplayIndex;
    private float indexChangeRate;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isInReplayMode = !isInReplayMode;

            if (isInReplayMode)
            {
                SetTransform(0);
                rb.isKinematic = true;
            }
            else
            {
                SetTransform(recordReplays.Count - 1);
                rb.isKinematic = false;
            }
        }

        indexChangeRate = 0;

        if (Input.GetKey(KeyCode.RightArrow))
            indexChangeRate = 1;

        if (Input.GetKey(KeyCode.LeftArrow))
            indexChangeRate = -1;

        if (Input.GetKey(KeyCode.LeftShift))
            indexChangeRate *= 0.5f;
    }

    private void FixedUpdate()
    {
        if (!isInReplayMode)
            recordReplays.Add(new RecordReplay 
                            {position = transform.position, rotation = transform.rotation});
        else
        {
            float nextIndex = currentReplayIndex + indexChangeRate;
            
            if (nextIndex < recordReplays.Count && nextIndex >= 0)
                SetTransform(nextIndex);
        }
    }

    private void SetTransform(float index)
    {
        currentReplayIndex = index;
        
        RecordReplay recordReplay = recordReplays[(int)index];

        transform.position = recordReplay.position;
        transform.rotation = recordReplay.rotation;
    }
}
