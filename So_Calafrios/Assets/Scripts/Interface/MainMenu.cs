using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Class which interact with the buttons pressed by the player in
/// the main menu.
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject fadeCanvas;
    [SerializeField] private CanvasGroup image;
    [SerializeField] private float transitionSpeed;
    [SerializeField] private float transitionTimeSpeed;
    [SerializeField] private int tutorialSceneNumber;

    /// <summary>
    /// Public method that loads the next scene depending of the scene number.
    /// </summary>
    private void PlayGame ()
    {
        fadeCanvas.SetActive(true);
        StartCoroutine(Transition(tutorialSceneNumber));
    }

    /// <summary>
    /// Public method which leaves the application, does not work on the editor.
    /// </summary>
    private void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Private Courotina that does the fade in and loads the scene.
    /// </summary>
    /// <param name="sceneNumber">Number of the scene to load.</param>
    private IEnumerator Transition(int sceneNumber)
    {
        // This is for the battery of the flashlight.
        while(image.alpha != 1f)
        {
            image.alpha += transitionSpeed;

            if(image.alpha > 1f)
            {
                image.alpha = 1f;
            }

            yield return new WaitForSeconds(transitionTimeSpeed);
        }

        SceneManager.LoadScene(sceneNumber);
    }
}
