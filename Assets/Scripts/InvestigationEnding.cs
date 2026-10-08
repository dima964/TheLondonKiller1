using UnityEngine;

public class InvestigationEnding : MonoBehaviour
{
    [SerializeField] private SuspectSelection suspectSelection;

    private bool endingStarted;

    private void Update()
    {
        if (endingStarted)
        {
            return;
        }

        if (NotebookManager.Instance == null)
        {
            return;
        }

        if (!NotebookManager.Instance.HasAllClues())
        {
            return;
        }

        StartEnding();
    }

    private void StartEnding()
    {
        endingStarted = true;

        if (suspectSelection != null)
        {
            suspectSelection.OpenSelection();
        }

        UnityEngine.Debug.Log("All clues collected. Final suspect selection is available.");
    }
}