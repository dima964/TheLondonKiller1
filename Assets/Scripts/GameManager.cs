using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Investigation")]
    [SerializeField] private int totalLetters = 5;

    private int lettersFound;

    public int LettersFound => lettersFound;
    public int TotalLetters => totalLetters;

    private Vector3 lastCheckpoint;
    private bool hasCheckpoint;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CollectLetter(Vector3 checkpointPosition)
    {
        lettersFound++;

        lastCheckpoint = checkpointPosition;
        hasCheckpoint = true;

        UnityEngine.Debug.Log($"Letter found: {lettersFound}/{totalLetters}");

        if (lettersFound >= totalLetters)
        {
            CompleteInvestigation();
        }
    }

    public void PlayerDied()
    {
        UnityEngine.Debug.Log("Player died.");

        RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        if (!hasCheckpoint)
        {
            UnityEngine.Debug.Log("No checkpoint available.");
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            player.transform.position = lastCheckpoint;
        }
    }

    private void CompleteInvestigation()
    {
        UnityEngine.Debug.Log("All letters found. Investigation complete.");
    }
}