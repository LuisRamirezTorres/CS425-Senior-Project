using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectHoopsScore : MonoBehaviour
{
    private int score = 0;
    private float time_remaining = 60.0f;
    public TextMeshPro score_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_remaining -= Time.deltaTime;
        score_text.text = "Score: " + score.ToString() + "\n" + "Time: " + Math.Max(Math.Floor(time_remaining), 0).ToString();

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        print(other.tag);
        Destroy(other.gameObject);
        if (time_remaining > 0)
        {
            score++;
        }
    }
    void restart()
    {
        if (time_remaining <= 0)
        {
            Debug.Log("restarting...");
            time_remaining = 60.0f;
            score = 0;

        }
    }
}
