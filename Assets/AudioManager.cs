using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------------Audio Source--------------")]
    [SerializeField] AudioSource musicSource;

    [Header("--------------Audio Clip--------------")]
    public AudioClip background;

    private static AudioManager instance;

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

   
    public void StopBGM()
    {
        musicSource.Stop();
    }
}
