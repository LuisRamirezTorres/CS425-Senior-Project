using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationBowlingBall : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab, new Vector3(0.702f, .324f, 18.388f), Quaternion.identity);
    }
}
