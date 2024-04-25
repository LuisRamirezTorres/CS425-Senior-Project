using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{


    private GameManager instance;
    public TextMeshProUGUI gameOverText;
    public SkeeballGestures endGame;

    // Start is called before the first frame update
    public void Start()
    {
        instance = GameManager.Instance;
    }

    // Update is called once per frame
    public void SetUp()
    {
        gameObject.SetActive(true);
        endGame.Setup();
        gameOverText.text = instance.getScore().ToString() +" POINTS!\n";
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Skeeball");
    }
}
