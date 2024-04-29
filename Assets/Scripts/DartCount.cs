using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DartCount : MonoBehaviour
{
    public static DartCount instance;
    
    [SerializeField]
    private TMP_Text dartText;
    
    [SerializeField]
    private int currentDarts = 2;
    
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

    public void ResetDartCount()
    {
        currentDarts = 8;
        dartText.text = currentDarts.ToString() + dartStr;
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
