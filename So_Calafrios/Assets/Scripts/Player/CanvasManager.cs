using UnityEngine;
using TMPro;

/// <summary>
/// Class that manages the canvas of the player.
/// </summary>
public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject interactionPanel = default;
    [SerializeField] private TextMeshProUGUI interactionText = default;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        HideInteractionPanel();
    }

    /// <summary>
    /// Public method that desactivates the interaction panel.
    /// </summary>
    public void HideInteractionPanel()
    {
        interactionPanel.SetActive(false);
    }

    /// <summary>
    /// Public method that activates the interaction panel with the interactive
    /// text.
    /// </summary>
    /// <param name="message">The interactive text in string.</param>
    public void ShowInteractionPanel(string message)
    {
        interactionText.text = message;
        interactionPanel.SetActive(true);
    }
}