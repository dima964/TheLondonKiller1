using UnityEngine;
using UnityEngine.UI;

public class SuspectSelection : MonoBehaviour
{
    [Header("Suspects")]
    [SerializeField] private Button[] suspectButtons;

    [Tooltip("Index of the correct suspect. 0 = first button, 7 = eighth button.")]
    [SerializeField] private int killerIndex;

    [Header("Ending")]
    [SerializeField] private GameObject selectionPanel;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject wrongAnswerPanel;

    private bool selectionActive;

    private void Start()
    {
        HideAllPanels();

        for (int i = 0; i < suspectButtons.Length; i++)
        {
            int suspectIndex = i;

            if (suspectButtons[i] != null)
            {
                suspectButtons[i].onClick.AddListener(
                    () => SelectSuspect(suspectIndex)
                );
            }
        }
    }

    public void OpenSelection()
    {
        if (selectionActive)
        {
            return;
        }

        selectionActive = true;

        if (selectionPanel != null)
        {
            selectionPanel.SetActive(true);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void SelectSuspect(int index)
    {
        if (!selectionActive)
        {
            return;
        }

        if (index == killerIndex)
        {
            CorrectSuspect();
        }
        else
        {
            WrongSuspect();
        }
    }

    private void CorrectSuspect()
    {
        selectionActive = false;

        if (selectionPanel != null)
        {
            selectionPanel.SetActive(false);
        }

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayVictoryMusic();
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        UnityEngine.Debug.Log("Correct suspect. Case solved.");
    }

    private void WrongSuspect()
    {
        if (wrongAnswerPanel != null)
        {
            wrongAnswerPanel.SetActive(true);
        }

        UnityEngine.Debug.Log("Wrong suspect selected.");
    }

    public void CloseWrongAnswer()
    {
        if (wrongAnswerPanel != null)
        {
            wrongAnswerPanel.SetActive(false);
        }
    }

    private void HideAllPanels()
    {
        if (selectionPanel != null)
        {
            selectionPanel.SetActive(false);
        }

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }

        if (wrongAnswerPanel != null)
        {
            wrongAnswerPanel.SetActive(false);
        }
    }
}