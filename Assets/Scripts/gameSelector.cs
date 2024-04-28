using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class gameSelector : MonoBehaviour
{
    
  
    public static int gameCountReference;

    private AudioManager audioManager; 

    void Start()
    {
        
        
        gameCountReference = 0;

        // Find AudioManager instance in the scene
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void chooseGame()
    {
        string ClickedButtonName = EventSystem.current.currentSelectedGameObject.name;

        if (ClickedButtonName == "playBasketball")
        {
            gameCountReference = 0;
            playGame();
        }
        else if (ClickedButtonName == "playSkeeball")
        {
            gameCountReference = 1;
            playGame();
        }
        else if (ClickedButtonName == "playDarts")
        {
            gameCountReference = 2;
            playGame();
        }

        else if(ClickedButtonName == "menuButton")
        {
            goToMenu();
        }
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
            SceneManager.LoadScene("Skeeball");
        }
        else if (gameCountReference == 2)
        {
            SceneManager.LoadScene("Darts");
        }
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
