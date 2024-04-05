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

    private AudioManager audioManager; 

    void Start()
    {
        basketBallPanel.SetActive(true);
        bowlingPanel.SetActive(false);
        skeeBallPanel.SetActive(false);
        dartsPanel.SetActive(false);
        gameCountReference = 0;

        // Find AudioManager instance in the scene
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void playGame()
    {
        // Stop background music before loading a new scene
        if (audioManager != null)
        {
            audioManager.StopBGM();
        }

        // Load the selected game scene
        if (gameCountReference == 0)
        {
            SceneManager.LoadScene("Basketball");
        }
        else if (gameCountReference == 1)
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
