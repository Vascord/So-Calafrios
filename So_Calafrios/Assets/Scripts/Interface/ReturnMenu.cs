using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    public void Return()
    {
        // Returns to Menu
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(1);
    }
}
