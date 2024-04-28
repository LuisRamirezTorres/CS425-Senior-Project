using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject volumePanel;
    public GameObject settingsPanel;

    void Start()
    {
        volumePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void callVolume()
    {
        volumePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void backButton()
    {
        volumePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

};
