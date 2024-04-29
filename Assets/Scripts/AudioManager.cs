using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    public AudioClip background;

    private static AudioManager instance;

    public AudioSource MusicSource
    {
        get { return musicSource; }
    }

    void Awake()
    {
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

    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void StopBGM()
    {
        musicSource.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }
}
