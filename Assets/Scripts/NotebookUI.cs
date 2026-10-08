using TMPro;
using UnityEngine;

public class NotebookUI : MonoBehaviour
{
    [Header("Notebook")]
    [SerializeField] private GameObject notebookPanel;

    [Header("Clue Text")]
    [SerializeField] private TextMeshProUGUI clueText;

    private bool isOpen;

    private void Start()
    {
        CloseNotebook();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleNotebook();
        }
    }

    public void ToggleNotebook()
    {
        if (isOpen)
        {
            CloseNotebook();
        }
        else
        {
            OpenNotebook();
        }
    }

    public void OpenNotebook()
    {
        isOpen = true;

        notebookPanel.SetActive(true);

        UpdateNotebook();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseNotebook()
    {
        isOpen = false;

        notebookPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UpdateNotebook()
    {
        if (NotebookManager.Instance == null)
        {
            return;
        }

        string notebookText = "";

        for (int i = 0; i < NotebookManager.Instance.CluesFound; i++)
        {
            notebookText += $"{i + 1}. {NotebookManager.Instance.GetClue(i)}\n\n";
        }

        if (NotebookManager.Instance.CluesFound == 0)
        {
            notebookText = "No clues found yet.";
        }

        clueText.text = notebookText;
    }
}