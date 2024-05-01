using Leap.Unity;
using Leap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveGesture : MonoBehaviour
{
    // Start is called before the first frame update
    public LeapProvider leapProvider;
    public float left_hand_timer = 2.0f;
    public float right_hand_timer = 2.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (left_hand_timer <= 0)
        {
            Debug.Log("WAVING_LEFT");
            left_hand_timer = 2.0f;
            SceneManager.LoadScene("GameSelection");
        }
        if (right_hand_timer <= 0)
        {
            Debug.Log("WAVING_Right");
            right_hand_timer = 2.0f;
            SceneManager.LoadScene("GameSelection");

        }
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
        //Use a helpful utility function to get the first hand that matches the Chirality
        Hand _leftHand = frame.GetHand(Chirality.Left);
        Hand _rightHand = frame.GetHand(Chirality.Right);


        //When we have a valid left hand, we can begin searching for more Hand information
        //if (_leftHand != null && _rightHand != null)
        //{
        //OnUpdateHands(_leftHand, _rightHand);
        //}
        if (_leftHand != null)
        {
            OnUpdateHandsLeft(_leftHand);
        }
        if (_rightHand != null)
        {
            OnUpdateHandsRight(_rightHand);
        }
    }
    void OnUpdateHands(Hand left_hand, Hand right_hand)
    {

        if (Waving(left_hand))
        {
            left_hand_timer -= Time.deltaTime;
        }
        else
        {
            left_hand_timer = 2.0f;
        }
        if (Waving(right_hand))
        {
            right_hand_timer -= Time.deltaTime;
        }
        else
        {
            right_hand_timer = 2.0f;
        }

    }
    void OnUpdateHandsLeft(Hand left_hand)
    {

        if (Waving(left_hand))
        {
            left_hand_timer -= Time.deltaTime;
        }
        else
        {
            left_hand_timer = 2.0f;
        }

    }
    void OnUpdateHandsRight(Hand right_hand)
    {

        if (Waving(right_hand))
        {
            right_hand_timer -= Time.deltaTime;
        }
        else
        {
            right_hand_timer = 2.0f;
        }

    }
    bool Waving(Hand hand)
    {
        foreach (Finger finger in hand.Fingers)
        {

            if (!finger.IsExtended)
            {
                return false;
            }
        }
        return true;

    }


}
