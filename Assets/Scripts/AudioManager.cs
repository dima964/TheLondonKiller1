using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource ambientSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectsSource;

    [Header("Sounds")]
    [SerializeField] private AudioClip rainSound;
    [SerializeField] private AudioClip letterSound;
    [SerializeField] private AudioClip bloodSound;
    [SerializeField] private AudioClip killerMusic;
    [SerializeField] private AudioClip victoryMusic;
    [SerializeField] private AudioClip deathSound;

    [Header("Volumes")]
    [SerializeField] private float ambientVolume = 0.5f;
    [SerializeField] private float musicVolume = 0.5f;
    [SerializeField] private float effectsVolume = 1f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        PlayRain();
    }

    public void PlayRain()
    {
        if (ambientSource == null || rainSound == null)
        {
            return;
        }

        ambientSource.clip = rainSound;
        ambientSource.volume = ambientVolume;
        ambientSource.loop = true;
        ambientSource.Play();
    }

    public void PlayLetterSound()
    {
        if (effectsSource == null || letterSound == null)
        {
            return;
        }

        effectsSource.PlayOneShot(letterSound, effectsVolume);
    }

    public void PlayBloodSound()
    {
        if (effectsSource == null || bloodSound == null)
        {
            return;
        }

        effectsSource.PlayOneShot(bloodSound, effectsVolume);
    }

    public void StartKillerMusic()
    {
        if (musicSource == null || killerMusic == null)
        {
            return;
        }

        musicSource.clip = killerMusic;
        musicSource.volume = musicVolume;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopKillerMusic()
    {
        if (musicSource == null)
        {
            return;
        }

        musicSource.Stop();
    }

    public void PlayVictoryMusic()
    {
        if (musicSource == null || victoryMusic == null)
        {
            return;
        }

        musicSource.Stop();
        musicSource.loop = false;
        musicSource.PlayOneShot(victoryMusic, musicVolume);
    }

    public void PlayDeathSound()
    {
        if (effectsSource == null || deathSound == null)
        {
            return;
        }

        effectsSource.PlayOneShot(deathSound, effectsVolume);
    }
}