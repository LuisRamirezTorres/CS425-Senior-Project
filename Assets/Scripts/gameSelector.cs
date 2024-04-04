using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameSelector : MonoBehaviour
{
    public GameObject basketBallPanel;
    public GameObject bowlingPanel;
    public GameObject skeeBallPanel;
    public GameObject dartsPanel;
    public static int gameCountReference;
    // Start is called before the first frame update
    void Start()
    {
        basketBallPanel.SetActive(true);
        bowlingPanel.SetActive(false);
        skeeBallPanel.SetActive(false);
        dartsPanel.SetActive(false);
        gameCountReference = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextGame()
    {
        if (gameCountReference == 0)
        {
            bowlingPanel.SetActive(true);
            basketBallPanel.SetActive(false);
            gameCountReference++;
        }
        else if (gameCountReference == 1){
            skeeBallPanel.SetActive(true);
            bowlingPanel.SetActive(false);
            gameCountReference++;
        }
        else if (gameCountReference == 2)
        {
            dartsPanel.SetActive(true);
            skeeBallPanel.SetActive(false);
            gameCountReference++;
        }
        else if (gameCountReference == 3)
        {
            basketBallPanel.SetActive(true);
            dartsPanel.SetActive(false);
            gameCountReference = 0;
        }
    }

    public void previousGame()
    {
        if (gameCountReference == 0)
        {
            basketBallPanel.SetActive(false);
            dartsPanel.SetActive(true);
            gameCountReference = 3;
        }
        else if (gameCountReference == 1)
        {
            bowlingPanel.SetActive(false);
            basketBallPanel.SetActive(true);
            gameCountReference--;
        }
        else if (gameCountReference == 2)
        {
            skeeBallPanel.SetActive(false);
            bowlingPanel.SetActive(true);
            gameCountReference--;
        }
        else if (gameCountReference == 3)
        {
            dartsPanel.SetActive(false);
            skeeBallPanel.SetActive(true);
            gameCountReference--;
        }
    }
    public void playGame()
    {
        if (gameCountReference == 0)
        {
            SceneManager.LoadScene("Basketball");
        }

        else if(gameCountReference == 1)
        {
            SceneManager.LoadScene("BowlingAlley");
        }
        else if (gameCountReference == 2)
        {
            SceneManager.LoadScene("Skeeball");
        }
        else if (gameCountReference == 3)
        {
            SceneManager.LoadScene("Darts");
        }
    }

    public void goToMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }

}

