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

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        StartCoroutine(Transition());
    }

    /// <summary>
    /// Private Courotina that does the fade out.
    /// </summary>
    private IEnumerator Transition()
    {
        // This is for the battery of the flashlight.
        while(image.alpha != 0f)
        {
            image.alpha -= transitionSpeed;

            if(image.alpha < 0f)
            {
                image.alpha = 0f;
            }

            yield return new WaitForSeconds(transitionTimeSpeed);
        }

        gameObject.SetActive(false);
    }
}
