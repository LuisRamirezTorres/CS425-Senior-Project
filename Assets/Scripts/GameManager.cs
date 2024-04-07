using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int currentScore;
    private int ballCount;
    public Camera cam;
    
    private Vector3 cameraVec = new Vector3(-0.4f, 1f, 6f);

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
        _instance.ballCount = 10;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
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

    public void resetCamera()
    {
        cam.transform.position = cameraVec;
    }




}


