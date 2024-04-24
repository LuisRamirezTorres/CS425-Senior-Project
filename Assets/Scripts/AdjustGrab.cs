using System.Collections;
using System.Collections.Generic;
using Leap.Interaction.Internal.InteractionEngineUtility;
using Leap.Unity.Interaction;
using Leap.Unity.Interaction.Internal;
using LeapInternal;
using UnityEngine;

public class AdjustGrab : MonoBehaviour
{
    private GrabClassifierHeuristics.ClassifierParameters grab;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("in adjust grab");
        grab.MAXIMUM_CURL = 0.2f;
    }

}
