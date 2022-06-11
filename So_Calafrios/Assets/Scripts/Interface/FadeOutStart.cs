using System.Collections;
using UnityEngine;

/// <summary>
/// Class which does the fade out when the game object is started.
/// </summary>
public class FadeOutStart : MonoBehaviour
{
    [SerializeField] private CanvasGroup image;
    [SerializeField] private float transitionSpeed;
    [SerializeField] private float transitionTimeSpeed;
    [SerializeField] private bool listenerFirstScene;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        if(listenerFirstScene)
        {
            AudioListener.volume = 0f;
        }
        StartCoroutine(Transition());
    }

    /// <summary>
    /// Private Coroutine that does the fade out.
    /// </summary>
    private IEnumerator Transition()
    {
        // While the image is visible, then it fades out.
        while(image.alpha != 0f)
        {
            image.alpha -= transitionSpeed;
            AudioListener.volume += transitionSpeed;

            if(image.alpha < 0f)
            {
                image.alpha = 0f;
            }
            if(AudioListener.volume > 1f)
            {
                AudioListener.volume = 1f;
            }

            yield return new WaitForSeconds(transitionTimeSpeed);
        }

        gameObject.SetActive(false);
    }
}
