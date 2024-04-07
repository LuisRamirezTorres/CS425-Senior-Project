using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using static Leap.Unity.Detector;
using UnityEngine.SceneManagement;

public class MenuPose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  /*  void OnUpdateFrame(Frame frame)
    {
        //Use a helpful utility function to get the first hand that matches the Chirality
        Hand _leftHand = frame.GetHand(Chirality.Left);

        //When we have a valid left hand, we can begin searching for more Hand information
        if (_leftHand != null)
        {
            OnUpdateHand(_leftHand);
        }
    }

    void onUpdateHand(Hand _hand)
    {
        Finger _thumb = _hand.GetThumb();
        if (_thumb.IsExtended)
        {
            SceneManager.LoadScene(1);
        }

    }
  */

}
