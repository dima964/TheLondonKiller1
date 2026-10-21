using UnityEngine;

public class LetterAudioTrigger : MonoBehaviour
{
    private void OnDestroy()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayLetterSound();
        }
    }
}