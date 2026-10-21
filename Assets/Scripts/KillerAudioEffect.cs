using UnityEngine;

public class KillerAudioEffect : MonoBehaviour
{
    [SerializeField] private KillerController killer;

    private bool musicPlaying;

    private void Update()
    {
        if (killer == null || AudioManager.Instance == null)
        {
            return;
        }

        if (killer.IsActive && !musicPlaying)
        {
            AudioManager.Instance.StartKillerMusic();
            musicPlaying = true;
        }
        else if (!killer.IsActive && musicPlaying)
        {
            AudioManager.Instance.StopKillerMusic();
            musicPlaying = false;
        }
    }
}