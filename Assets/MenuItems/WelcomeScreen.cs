using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void enterGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
   
}

