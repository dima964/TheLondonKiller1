using System.Collections.Generic;
using UnityEngine;

public class NotebookManager : MonoBehaviour
{
    public static NotebookManager Instance { get; private set; }

    [Header("Notebook")]
    [SerializeField] private int maximumClues = 5;

    private readonly List<string> clues = new List<string>();

    public IReadOnlyList<string> Clues => clues;
    public int CluesFound => clues.Count;
    public int MaximumClues => maximumClues;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddClue(string clue)
    {
        if (string.IsNullOrWhiteSpace(clue))
        {
            UnityEngine.Debug.LogWarning("Tried to add an empty clue.");
            return;
        }

        if (clues.Count >= maximumClues)
        {
            UnityEngine.Debug.LogWarning("Notebook already contains the maximum number of clues.");
            return;
        }

        clues.Add(clue);

        UnityEngine.Debug.Log($"Clue added to notebook: {clue}");
    }

    public string GetClue(int index)
    {
        if (index < 0 || index >= clues.Count)
        {
            return string.Empty;
        }

        return clues[index];
    }

    public bool HasAllClues()
    {
        return clues.Count >= maximumClues;
    }

    public void ClearClues()
    {
        clues.Clear();
    }
}