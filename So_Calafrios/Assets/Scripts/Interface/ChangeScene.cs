using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class which returns to the menu when called.
/// </summary>
public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int sceneNumber;

    /// <summary>
    /// Public method called to return to the menu.
    /// </summary>
    public void ChangeToNumberScene()
    {
        if(sceneNumber == 0)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        SceneManager.LoadScene(sceneNumber);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
