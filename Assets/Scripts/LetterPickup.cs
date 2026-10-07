using UnityEngine;

public class LetterPickup : MonoBehaviour
{
    [Header("Letter")]
    [SerializeField] private string letterContent;

    private bool collected;

    private void OnTriggerEnter(Collider other)
    {
        if (collected)
        {
            return;
        }

        if (!other.CompareTag("Player"))
        {
            return;
        }

        CollectLetter();
    }

    private void CollectLetter()
    {
        collected = true;

        GameManager.Instance.CollectLetter(transform.position);

        UnityEngine.Debug.Log($"Letter collected: {letterContent}");

        Destroy(gameObject);
    }
}