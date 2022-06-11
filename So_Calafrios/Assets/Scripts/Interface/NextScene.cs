using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextScene : MonoBehaviour
{
    [SerializeField] private GameObject transitionCanvas;
    [SerializeField] private CanvasGroup image;
    [SerializeField] private float transitionSpeed;
    [SerializeField] private float transitionTimeSpeed;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) { LoadNextScene();}
    }

    /// <summary>
    /// Public method called to activate the Coroutine.
    /// </summary>
    public void LoadNextScene()
    {
        transitionCanvas.SetActive(true);
        StartCoroutine(Transition());
    }

    /// <summary>
    /// Private Coroutine that does the fade in and loads the next scene.
    /// </summary>
    private IEnumerator Transition()
    {
        
        // While the image is not fully visible, then it fades in.
        while(image.alpha != 1f)
        {
            image.alpha += transitionSpeed;
            AudioListener.volume -= transitionSpeed;

            if(image.alpha > 1f)
            {
                image.alpha = 1f;
            }
            if(AudioListener.volume < 0f)
            {
                AudioListener.volume = 0f;
            }

            yield return new WaitForSeconds(transitionTimeSpeed);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
