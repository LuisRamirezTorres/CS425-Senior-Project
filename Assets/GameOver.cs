using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] 
    private GesturesGameOver gestures;
    
    [SerializeField] 
    private DartCount dartCount;

    [SerializeField] 
    private DartboardScore score;
    
    public TMP_Text pointsText;
    
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " Points";
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Darts");
    }
}
