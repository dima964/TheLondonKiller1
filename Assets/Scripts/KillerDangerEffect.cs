using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class KillerDangerEffect : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private KillerController killer;
    [SerializeField] private UnityEngine.UI.Image dangerOverlay;

    [Header("Effect")]
    [SerializeField] private float fadeSpeed = 3f;
    [SerializeField] private float maximumAlpha = 0.45f;

    private void Start()
    {
        if (dangerOverlay != null)
        {
            Color color = dangerOverlay.color;
            color.a = 0f;
            dangerOverlay.color = color;
        }
    }

    private void Update()
    {
        if (killer == null || dangerOverlay == null)
        {
            return;
        }

        float targetAlpha = killer.IsActive ? maximumAlpha : 0f;

        Color color = dangerOverlay.color;

        color.a = Mathf.MoveTowards(
            color.a,
            targetAlpha,
            fadeSpeed * Time.deltaTime
        );

        dangerOverlay.color = color;
    }
}