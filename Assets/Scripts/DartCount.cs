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

    public int GetDartCount()
    {
        return currentDarts;
    }

    public void DecreaseDarts()
    {
        currentDarts--;
        dartText.text = currentDarts.ToString() + dartStr;
        Debug.Log("Decreasing Dart Count to: " + dartText.text);
        if (GetDartCount() == -1)
            dartText.text = 0 + dartStr;
    }
    
}
