using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectHoopsScore : MonoBehaviour
{
    private int score = 0;
    private float time_remaining = 60.0f;
    private float disable_time = 0.25f;
    private bool collider_disabled = false;
    public TextMeshProUGUI score_text;
    public GameObject basketballMachine;
    private bool game_started = true;
    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverText;
    public HoopsGameloopController gameloopController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time_remaining -= Time.deltaTime;
        score_text.text = "Score: " + score.ToString() + "\n" + "Time: " + Math.Max(Math.Floor(time_remaining), 0).ToString();
        if (time_remaining <= 0 && game_started)
        {
            game_started = false;
            gameOverScreen.SetActive(true);
            gameOverText.text = "Score: " + score.ToString();
            gameloopController.enabled = true;

        }
        if (collider_disabled && disable_time > 0)
        {
            disable_time -= Time.deltaTime;
        }
        else if (collider_disabled && disable_time <= 0)
        {
            collider_disabled = false;
            basketballMachine.GetComponent<MeshCollider>().enabled = true;
            disable_time = 0.25f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        print(other.tag);
        //Destroy(other.gameObject);
        if (time_remaining > 0)
        {
            score++;
        }
        basketballMachine.GetComponent<MeshCollider>().enabled = false;
        collider_disabled = true;
    }
    void restart()
    {
        if (time_remaining <= 0)
        {
            Debug.Log("restarting...");
            time_remaining = 60.0f;
            score = 0;
            game_started = true;
            gameOverScreen.SetActive(false);
            gameloopController.enabled = false;


        }
    }
}
