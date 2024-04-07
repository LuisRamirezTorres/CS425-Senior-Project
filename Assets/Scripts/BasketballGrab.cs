using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
public class BasketballGrab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Hand _hand = Hands.Provider.GetHand(Chirality.Left); //Get just the left hand.
        float _grabStrength = _hand.GrabStrength;
        Debug.Log(_grabStrength);
    }
}
