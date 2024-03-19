using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    private GameManager instance;
    public TextMeshProUGUI gameOverText;


    public void Start()
    {
        instance = GameManager.Instance;
    }
    public void SetUp()
    {
        gameObject.SetActive(true);
        gameOverText.text = instance.getScore().ToString() + " POINTS\n";
    }
}
