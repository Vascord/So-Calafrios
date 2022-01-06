using System.Collections;
using UnityEngine;

public class FadeOutStart : MonoBehaviour
{
    [SerializeField] private CanvasGroup image;
    [SerializeField] private float transitionSpeed;
    [SerializeField] private float transitionTimeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Transition());
    }

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
