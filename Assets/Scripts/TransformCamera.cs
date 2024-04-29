using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformCamera : MonoBehaviour
{
    [SerializeField]
    private Vector3 cameraPos;

    [SerializeField] 
    private DartboardScore dartboardScore;
    
    [SerializeField] 
    private Camera mainCamera;
    
    [SerializeField]
    private GameObject dartPos;

    // Update is called once per frame
    private void Update()
    {
        StartCoroutine(SetCameraPosition(cameraPos, mainCamera, dartPos));
    }
    
    IEnumerator SetCameraPosition(Vector3 cameraPos, Camera mainCamera, GameObject dartPos)
    {
        yield return new WaitForSeconds(1f);
        mainCamera.transform.position = dartboardScore.dartPrefabPos - Vector3.right;
        gameObject.SetActive(false);
    }
}
