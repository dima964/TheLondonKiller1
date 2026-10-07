using UnityEngine;

public class KillerEncounter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private KillerController killer;
    [SerializeField] private PlayerController player;

    [Header("Encounter")]
    [SerializeField] private float hidingTime = 5f;

    private bool encounterActive;
    private float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (encounterActive)
        {
            return;
        }

        if (!other.CompareTag("Player"))
        {
            return;
        }

        StartEncounter();
    }

    private void Update()
    {
        if (!encounterActive)
        {
            return;
        }

        CheckPlayer();

        timer += Time.deltaTime;

        if (timer >= hidingTime)
        {
            SurviveEncounter();
        }
    }

    private void StartEncounter()
    {
        encounterActive = true;
        timer = 0f;

        killer.StartEncounter();

        UnityEngine.Debug.Log("Killer encounter started.");
    }

    private void CheckPlayer()
    {
        if (player.IsCrouching)
        {
            UnityEngine.Debug.Log("Player is hiding.");
        }
    }

    private void SurviveEncounter()
    {
        encounterActive = false;

        killer.EndEncounter();

        UnityEngine.Debug.Log("Player survived the killer encounter.");
    }
}