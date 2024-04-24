using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCamera : MonoBehaviour
{
    [SerializeField]
    private Vector3 cameraPos;

    [SerializeField] 
    private DartboardScore dartboardScore;
    
    [SerializeField] 
    private Camera mainCamera;
    
    private void Update()
    {
        StartCoroutine(ResetCameraPosition(cameraPos, mainCamera));
    }

    IEnumerator ResetCameraPosition(Vector3 cameraPos, Camera mainCamera)
    {
        Debug.Log("In ResetCameraPosition()");
        yield return new WaitForSeconds(3f);
        cameraPos = dartboardScore.cameraPos;
        mainCamera.transform.position = cameraPos;
        gameObject.SetActive(false);
    }
    
}
