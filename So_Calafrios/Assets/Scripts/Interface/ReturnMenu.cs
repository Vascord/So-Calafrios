using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class which returns to the menu when called.
/// </summary>
public class ReturnMenu : MonoBehaviour
{
    /// <summary>
    /// Public method called to return to the menu.
    /// </summary>
    public void Return()
    {
        // Returns to Menu
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
}
