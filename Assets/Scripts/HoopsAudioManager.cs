using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopsAudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource aud;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //aud.Play();
        }
    }

    public void PlayBounce()
    {
        aud.Play();
    }

}
