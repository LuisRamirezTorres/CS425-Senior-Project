using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{


    private GameManager instance;
    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    public void Start()
    {
        instance = GameManager.Instance;
    }

    // Update is called once per frame
    public void SetUp()
    {
        gameObject.SetActive(true);
        gameOverText.text = instance.getScore().ToString() +" POINTS!\n";
    }
}
