using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class that interact with the buttons pressed by the player
/// in the pause menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private static bool gameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI = default;
    // [SerializeField] private AudioListener player = default;
    // [SerializeField] private GameObject settings = default;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // Gets the button escape to pause or resume the game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                Pause();
            }
            else if(gameIsPaused /*&& settings.activeSelf*/)
            {
                // settings.SetActive(false);
                pauseMenuUI.SetActive(true);
            }
            else
            {
                Resume();
            }
        }
    }

    /// <summary>
    /// Private method which stops the game and permits the free
    /// movement of the mouse.
    /// </summary>
    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        AudioListener.pause = true;
    }

    /// <summary>
    /// Public method which resume the game and locks the mouse movement.
    /// </summary>
    private void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        AudioListener.pause = false;
    }

    /// <summary>
    /// Public method to returns to the menu scene.
    /// </summary>
    private void LoadMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        AudioListener.pause = false;
        SceneManager.LoadScene("Menu");
    }

    /// <summary>
    /// Public method to quit the game.
    /// </summary>
    private void QuitGame()
    {
        Application.Quit();
    }
}
