using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandleStartScreen : MonoBehaviour
{
    public DetectHoopsScore gameManager;
    public GameObject start_screen_canvas;
    public float start_screen_timer;
    public TextMeshProUGUI countdown_text;
    public TextMeshProUGUI countdown_text_num;
    private bool displaying = true;
    // Start is called before the first frame update
    void Start()
    {
        countdown_text.enabled = false;
        countdown_text_num.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        start_screen_timer -= Time.deltaTime;
        if (displaying && start_screen_timer <= 4)
        {
            countdown_text.enabled = true;
            countdown_text_num.enabled = true;
            if (start_screen_timer > 1)
            {
                countdown_text_num.text = Math.Floor(start_screen_timer).ToString();
            }
            else
            {
                countdown_text_num.text = "GO!";
            }

        }
        if (start_screen_timer <= 0 && displaying)
        {
            start_screen_canvas.SetActive(false);
            gameManager.restart();
            displaying = false;
        }
    }
}
