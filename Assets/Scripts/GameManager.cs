using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentScore;
    public int ballCount;
    public Camera cam;
    public GameObject floatText;
    public int tempScore;

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
        this.tempScore = score;
        
        var text = Instantiate(floatText, this.transform.position, Quaternion.Euler(0f, 90f, 0));
        text.GetComponent<TMP_Text>().text = tempScore.ToString();
        
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
        _instance.ballCount = 10;
        _instance.currentScore = 0;
        GameObject.Find("Background").gameObject.SetActive(false);
    }

    public void resetCamera()
    {
        cam.transform.position = cameraVec;
    }
    
    //public void showFloatingText()
    //{
    //    var text = Instantiate(floatText, this.transform.position, Quaternion.Euler(0f,90f,0f), this.transform);

    //    text.GetComponent<TMP_Text>().text = this.tempScore.ToString();


        //var newtext = text.ConvertTo<TextMeshPro>();
        //newtext.GetComponent<TextMeshPro>().text = points.ToString();
    //}





}


