using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using static Leap.Unity.Detector;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class gameSelector : MonoBehaviour
{
    public GameObject skeeBallPanel;
    public GameObject dartsPanel;
    public GameObject basketBallPanel;

    public static int gameCountReference;

    private AudioManager audioManager;


    public LeapProvider leapProvider;

    // Start is called before the first frame update

    private bool extendCheck;
    private bool canExecute;

    void Start()
    {
        basketBallPanel.SetActive(true);
        skeeBallPanel.SetActive(false);
        dartsPanel.SetActive(false);

        gameCountReference = 0;

        // Find AudioManager instance in the scene
        audioManager = FindObjectOfType<AudioManager>();


        StartCoroutine(MyCoroutine());
    }


    IEnumerator MyCoroutine()
    {
        Debug.Log("Coroutine started");

        yield return new WaitForSeconds(2); // Wait for 2 seconds

        Debug.Log("Coroutine resumed after waiting for 2 seconds");

        canExecute = true; 
    }





    private void OnEnable()
    {
        leapProvider.OnUpdateFrame += OnUpdateFrame;
    }
    private void OnDisable()
    {
        leapProvider.OnUpdateFrame -= OnUpdateFrame;
    }

    void OnUpdateFrame(Frame frame)
    {
        // Use a helpful utility function to get the first hand that matches the Chirality
        Hand _leftHand = frame.GetHand(Chirality.Left);
        Hand _rightHand = frame.GetHand(Chirality.Right);

        // When we have a valid left hand, we can begin searching for more Hand information
        if (_leftHand != null )
        {
            OnUpdateHand(_leftHand, "left");
           
        }

        if (_rightHand != null)
        {

            OnUpdateHand(_rightHand, "right");
        }
    }

    void OnUpdateHand(Hand _hand, string side)
    {



        if (IsExtended(_hand) && !extendCheck && side == "left" && canExecute)
        {
            Debug.Log("All fingers are extended right side");
            nextGame();
            // goToMenu();
            extendCheck = true;
            canExecute = false;
            StartCoroutine(MyCoroutine());
        }

        if (IsExtended(_hand) && !extendCheck && side == "right" && canExecute)
        {
            Debug.Log("All fingers are extended left side");
            previousGame();
            extendCheck = true;
            canExecute = false;
            StartCoroutine(MyCoroutine());
        }



        if (IsHangingLoose(_hand) && !extendCheck && side == "right")
        {
            Debug.Log("Hanging Loose");
            playGame();
            extendCheck = true;
        }


        if (IsThumbsUp(_hand) && !extendCheck && side == "left")
        {
            Debug.Log("Thumb is up");
            goToMenu();
            extendCheck = true;
        }

        /* if (isPointingLeft(_hand) && !extendCheck)
         {
             Debug.Log("Finger is pointing left");
             previousGame();
             extendCheck = true;
             StartCoroutine(MyCoroutine());

         }

         if (isPointingRight(_hand) && !extendCheck)
         {
             Debug.Log("Finger is pointing right");
             nextGame();
             extendCheck = true;
             StartCoroutine(MyCoroutine());
         }*/



        if (!IsExtended(_hand))
        {
            extendCheck = false;
        }

        if (!IsThumbsUp(_hand))
        {

            extendCheck = false;
        }

        if (!isPointingLeft(_hand))
        {
            extendCheck = false;
        }



    }

    bool IsExtended(Hand _hand)
    {
        bool isHandOpen;
        Finger _thumb = _hand.GetThumb();
        Finger _index = _hand.GetIndex();
        Finger _middle = _hand.GetMiddle();
        Finger _ring = _hand.GetRing();
        Finger _pinky = _hand.GetPinky();

        bool isThumb = _thumb.IsExtended;
        bool isIndex = _index.IsExtended;
        bool isMiddle = _middle.IsExtended;
        bool isRing = _ring.IsExtended;
        bool isPinky = _pinky.IsExtended;

        if (isThumb && isIndex && isMiddle && isRing && isPinky)
            isHandOpen = true;
        else
            isHandOpen = false;

        return isHandOpen;
    }

    bool isPointingLeft(Hand _hand)
    {
        bool isFingerLeft;
        Finger _thumb = _hand.GetThumb();
        Finger _index = _hand.GetIndex();
        Finger _middle = _hand.GetMiddle();
        Finger _ring = _hand.GetRing();
        Finger _pinky = _hand.GetPinky();

        bool isThumb = _thumb.IsExtended;
        bool isIndex = _index.IsExtended;
        bool isMiddle = _middle.IsExtended;
        bool isRing = _ring.IsExtended;
        bool isPinky = _pinky.IsExtended;
        
        
        Vector3 indexFingerDirection = _index.Direction;
       
        //Debug.Log("Index Finger Direction: " + indexFingerDirection);
        



        if (isIndex && indexFingerDirection.x < -.85)
        {
            isFingerLeft = true;
        }
        else
        {
            isFingerLeft = false;
        }
        return isFingerLeft;
       

    }

    bool isPointingRight(Hand _hand)
    {
        bool isFingerLeft;
        Finger _thumb = _hand.GetThumb();
        Finger _index = _hand.GetIndex();
        Finger _middle = _hand.GetMiddle();
        Finger _ring = _hand.GetRing();
        Finger _pinky = _hand.GetPinky();

        bool isThumb = _thumb.IsExtended;
        bool isIndex = _index.IsExtended;
        bool isMiddle = _middle.IsExtended;
        bool isRing = _ring.IsExtended;
        bool isPinky = _pinky.IsExtended;


        Vector3 indexFingerDirection = _index.Direction;
        
       

       // Debug.Log("Index Finger Direction: " + indexFingerDirection);




        if (isIndex && indexFingerDirection.x > .85)
        {
            isFingerLeft = true;
        }
        else
        {
            isFingerLeft = false;
        }
        return isFingerLeft;


    }

    bool twoFingers(Hand _hand)
    {
        bool two_Fingers;
        Finger _thumb = _hand.GetThumb();
        Finger _index = _hand.GetIndex();
        Finger _middle = _hand.GetMiddle();
        Finger _ring = _hand.GetRing();
        Finger _pinky = _hand.GetPinky();

        bool isThumb = _thumb.IsExtended;
        bool isIndex = _index.IsExtended;
        bool isMiddle = _middle.IsExtended;
        bool isRing = _ring.IsExtended;
        bool isPinky = _pinky.IsExtended;

        if (isThumb && isIndex && !isMiddle && !isRing && !isPinky)
        {
            two_Fingers = true;
            Debug.Log("2 Fingers Extended");
        }

        else
        {
            two_Fingers = false;
        }
        return two_Fingers;
    }


    bool IsHangingLoose(Hand _hand)
    {
        bool isThumbsUp;

        Finger _thumb = _hand.GetThumb();
        Finger _index = _hand.GetIndex();
        Finger _middle = _hand.GetMiddle();
        Finger _ring = _hand.GetRing();
        Finger _pinky = _hand.GetPinky();
        


        bool isThumb = _thumb.IsExtended;
        bool isIndex = _index.IsExtended;
        bool isMiddle = _middle.IsExtended;
        bool isRing = _ring.IsExtended;
        bool isPinky = _pinky.IsExtended;
        

        if (isThumb && !isIndex && !isMiddle && !isRing && isPinky)
            isThumbsUp = true;
        else
            isThumbsUp = false;

        return isThumbsUp;
    }

    bool IsThumbsUp(Hand _hand)
    {
        bool isThumbsUp;

        Finger _thumb = _hand.GetThumb();
        Finger _index = _hand.GetIndex();
        Finger _middle = _hand.GetMiddle();
        Finger _ring = _hand.GetRing();
        Finger _pinky = _hand.GetPinky();


        bool isThumb = _thumb.IsExtended;
        bool isIndex = _index.IsExtended;
        bool isMiddle = _middle.IsExtended;
        bool isRing = _ring.IsExtended;
        bool isPinky = _pinky.IsExtended;

        if (isThumb && !isIndex)
            isThumbsUp = true;
        else
            isThumbsUp = false;

        return isThumbsUp;
    }




    public void nextGame()
    {
        if (gameCountReference == 0)
        {
            skeeBallPanel.SetActive(true);
            basketBallPanel.SetActive(false);
            gameCountReference++;
            Debug.Log("GameCountReference" + gameCountReference);
        }
        else if (gameCountReference == 1)
        {

            dartsPanel.SetActive(true);
            skeeBallPanel.SetActive(false);
            Debug.Log("GameCountReference" + gameCountReference);
            gameCountReference++;
        }
        else if (gameCountReference == 2)
        {
            basketBallPanel.SetActive(true);
            dartsPanel.SetActive(false);
            gameCountReference = 0;
            Debug.Log("GameCountReference" + gameCountReference);
        }
    }

    public void previousGame()
    {
        if (gameCountReference == 0)
        {
            basketBallPanel.SetActive(false);
            dartsPanel.SetActive(true);
            gameCountReference = 2;
            Debug.Log("GameCountReference" + gameCountReference);
        }
        else if (gameCountReference == 1)
        {
            skeeBallPanel.SetActive(false);
            basketBallPanel.SetActive(true);
            gameCountReference--;
            Debug.Log("GameCountReference" + gameCountReference);
        }
        else if (gameCountReference == 2)
        {
            dartsPanel.SetActive(false);
            skeeBallPanel.SetActive(true);
            gameCountReference--;
            Debug.Log("GameCountReference" + gameCountReference);
        }
       
    }




    /* public void chooseGame()
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
    }*/

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
            Debug.Log("GameCountReference" + gameCountReference);
        }
        else if (gameCountReference == 1)
        {
            SceneManager.LoadScene("Skeeball");
            Debug.Log("GameCountReference" + gameCountReference);
        }
        else if (gameCountReference == 2)
        {
            SceneManager.LoadScene("dartsChivalry");
            Debug.Log("GameCountReference" + gameCountReference);
        }
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    


}
