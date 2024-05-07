using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    /*[SerializeField] 
    private GesturesGameOver gestures;*/
    
    [SerializeField] 
    private DartCount dartCount;

    [SerializeField] 
    private DartboardScore dartboardScore;
    
    public TMP_Text pointsText;
    
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = (score).ToString() + " Points";
    }

    public void NewGame()
    {
        dartboardScore.ResetScore();
        dartCount.ResetDartCount();
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("Tip Dart")){
            Destroy(gameObj);
        }
        gameObject.SetActive(false);
        /*SceneManager.LoadScene("Darts");*/
    }
}
