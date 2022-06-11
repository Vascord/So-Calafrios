using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class which makes the player change scenes or reload it.
/// </summary>
public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int sceneNumber;

    /// <summary>
    /// Public method called to change to another scene.
    /// </summary>
    public void ChangeToNumberScene()
    {
        if(sceneNumber == 0)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        SceneManager.LoadScene(sceneNumber);
    }

    /// <summary>
    /// Public method called to reload the actual scene.
    /// </summary>
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
