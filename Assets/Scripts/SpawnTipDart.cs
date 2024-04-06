using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using static Leap.Unity.Detector;

// Template taken from Ultraleap 
// https://docs.ultraleap.com/xr-and-tabletop/xr/unity/plugin/features/scripting-fundamentals.html
public class SpawnTipDart : MonoBehaviour
{
    
    [SerializeField]
    private Vector3 dartPos;
    
    [SerializeField]
    private Quaternion dartOrientation;
    
    [SerializeField]
    private DartCount dartCount;
    
    [SerializeField]
    private GameOver gameOver;
    
    [SerializeField]
    private GesturesGameOver gestures;
    
    [SerializeField]
    private DartboardScore score;
    
    private GameObject dartInstance;
    private bool isInstantiated;

    public LineRenderer dartLine;
    public LeapProvider leapProvider;
    public GameObject dartPrefab;
    
    void Start()
    {
        dartPos = dartPrefab.transform.position;  // Get current dart pos
        dartOrientation = dartPrefab.transform.rotation; // Get current dart orientation
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

        // When we have a valid left hand, we can begin searching for more Hand information
        if(_leftHand != null)
        {
            OnUpdateHand(_leftHand);
        }
    }

    void OnUpdateHand(Hand _hand)
    {
        if (dartCount.GetDartCount() == -1)
        {
            gameOver.Setup(score.GetScore());
            gestures.Setup();
        }
        
        // To respawn a dart, the left hand must be open, then unopened.
        if (IsExtended(_hand) && !isInstantiated)
        {
            Debug.Log("All fingers are extended");
            dartCount.DecreaseDarts();
            SpawnDart();
            isInstantiated = true;
        }

        if (!IsExtended(_hand))
        {
            isInstantiated = false;
        }
    }

    public void SpawnDart()
    {
        dartInstance = Instantiate(dartPrefab, dartPos, dartOrientation);
        
        // Get dart's DartTrajectoryLine component information and pass dartLine
        var dtl = dartInstance.GetComponent<DartTrajectoryLine>();
        dtl.lineRenderer = dartLine;
        
        Debug.Log("Instantiating new Tip Dart");
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
    
    
}
