using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextScene : MonoBehaviour
{
    [SerializeField] private CanvasGroup image;
    [SerializeField] private float transitionSpeed;
    [SerializeField] private float transitionTimeSpeed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) { LoadNextScene();}
    }

    public void LoadNextScene()
    {
        StartCoroutine(Transition());
    }

    /// <summary>
    /// Private Courotina that does the fade in and loads the scene.
    /// </summary>
    /// <param name="sceneNumber">Number of the scene to load.</param>
    private IEnumerator Transition()
    {
        
        // This is for the battery of the flashlight.
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
