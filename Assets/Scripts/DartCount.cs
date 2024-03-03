using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DartCount : MonoBehaviour
{
    public static DartCount instance;
    
    public TMP_Text dartText;
    public int currentDarts = 10;
    public string dartStr = " Darts";

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        dartText.text = currentDarts.ToString() + dartStr;
    }
    

    public void DecreaseDarts()
    {
        currentDarts--;
        dartText.text = currentDarts.ToString() + dartStr;
    }
    
}
