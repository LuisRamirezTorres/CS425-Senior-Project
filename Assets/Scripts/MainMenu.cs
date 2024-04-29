using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using static Leap.Unity.Detector;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour { 

    public LeapProvider leapProvider;

    private bool canExecute;

    // Start is called before the first frame update

    private bool extendCheck;

    private bool isPaused = true; // Initially pause the script
    private WaitForSeconds delay = new WaitForSeconds(5f);



    void Start()
    {
        canExecute = false;
        StartCoroutine(StartAfterDelay());
    }

    IEnumerator StartAfterDelay()
    {
        Debug.Log("Coroutine started");

        yield return new WaitForSeconds(5); // Wait for 5 seconds

        Debug.Log("Coroutine resumed after waiting for 5 seconds");

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
        if (_leftHand != null /*|| _rightHand != null*/)
        {
            OnUpdateHand(_leftHand,"left");
           // OnUpdateHand(_rightHand);
        }

        if(_rightHand != null)
        {
           
            OnUpdateHand(_rightHand, "right");
        }
    }

    void OnUpdateHand(Hand _hand, string side)
    {



        if (IsExtended(_hand) && !extendCheck && side == "right")
        {
            Debug.Log("All fingers are extended");
            enterSelection();
            extendCheck = true;
        }


        if (IsThumbsUp(_hand) && !extendCheck && side == "left")
        {
            Debug.Log("Thumb is up");
            enterSettings();
            extendCheck = true;
        }

        if (!IsExtended(_hand))
        {
            extendCheck = false;
        }

        if (!IsThumbsUp(_hand))
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


    public void enterSelection()
    {
        SceneManager.LoadScene("GameSelection");
    }

    public void enterSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

}
