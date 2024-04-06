using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvas : MonoBehaviour
{
    public GameObject canvasObject;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisableCanvas(canvasObject, 5.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DisableCanvas(GameObject canvasObj, float t)
    {
        yield return new WaitForSeconds(t);
        Debug.Log("Hiding Pop Up");
        Destroy(canvasObj);
    }
}
