using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class which interact with the buttons pressed by the player in
/// the main menu.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Public method that loads the next scene in the build settings order.
    /// </summary>
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Public method which leaves the application, does not work on the editor.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
