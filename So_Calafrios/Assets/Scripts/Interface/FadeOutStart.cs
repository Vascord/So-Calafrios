using System.Collections;
using UnityEngine;

public class FadeOutStart : MonoBehaviour
{
    [SerializeField] private CanvasGroup image;
    [SerializeField] private float transitionSpeed;
    [SerializeField] private float transitionTimeSpeed;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    void Start()
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
