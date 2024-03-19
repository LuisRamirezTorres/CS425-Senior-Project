using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentScore;
    public int ballCount;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
                
            }

            return _instance;
        }
    }


    private void Awake()
    {
        _instance = this;
        _instance.ballCount = 5;
    }


    public void addScore(int score)
    {

        this.currentScore += score;
        this.ballCount--;

    }

    public int getBallCount()
    {
        return this.ballCount;
    }

    public int getScore()
    {
        return this.currentScore;
    }

    public void newGame()
    {
        SceneManager.LoadScene("Skeeball");
    }





}


