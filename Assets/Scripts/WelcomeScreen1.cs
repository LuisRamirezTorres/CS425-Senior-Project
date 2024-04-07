using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScreen1 : MonoBehaviour
{
    public void ChangeWelcome()
    {
        SceneManager.LoadScene(1);
    }

}