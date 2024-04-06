using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOver gameOver;

    [SerializeField] 
    private int maxPlatform = 0;

    public void GameOverScreen()
    {
        gameOver.Setup(maxPlatform);
    }

    /*private void Awake()
    {
        throw new NotImplementedException();
    }

    private void Start()
    {
        throw new NotImplementedException();
    }*/
}
