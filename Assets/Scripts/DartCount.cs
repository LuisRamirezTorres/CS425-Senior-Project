using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DartCount : MonoBehaviour
{
    public static DartCount instance;
    
    public TMP_Text dartText;
    public int currentDarts = 5;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        dartText.text = currentDarts.ToString();
    }
    

    public void DecreaseDarts()
    {
        currentDarts--;
        dartText.text = currentDarts.ToString();
    }
    
}
