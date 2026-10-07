using UnityEngine;

public class KillerController : MonoBehaviour
{
    [Header("Killer")]
    [SerializeField] private float encounterDuration = 5f;

    private bool isActive;
    private float timer;

    public bool IsActive => isActive;

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= encounterDuration)
        {
            EndEncounter();
        }
    }

    public void StartEncounter()
    {
        isActive = true;
        timer = 0f;

        gameObject.SetActive(true);

        UnityEngine.Debug.Log("Killer appeared.");
    }

    public void EndEncounter()
    {
        isActive = false;
        timer = 0f;

        gameObject.SetActive(false);

        UnityEngine.Debug.Log("Killer disappeared.");
    }
}