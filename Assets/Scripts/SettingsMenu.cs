using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject volumePanel;
    public GameObject settingsPanel;
    public Slider volumeSlider;

    void Start()
    {
        volumePanel.SetActive(false);
        settingsPanel.SetActive(true);

        // Set the initial value of the volume slider to match the current music volume
        volumeSlider.value = AudioManager.GetInstance().MusicSource.volume;
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

    public void SetVolume()
    {
        Debug.Log("Slider value changed: " + volumeSlider.value);
        // Set the music volume to the value of the volume slider
        AudioManager.GetInstance().SetMusicVolume(volumeSlider.value);
    }
}
