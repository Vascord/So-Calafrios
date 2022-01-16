using UnityEngine;

public class OnTriggerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animationObject;
    [SerializeField] private bool lightModifier;
    [SerializeField] private bool lightOut;
    [SerializeField] private Flashlight flashlight;

    /// <summary>
    /// Private method called upon colliding with an object.
    /// </summary>
    /// <param name="other">Collider of the collinding object.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Activates animations when player enter.
        if(other.gameObject.CompareTag("Player"))
        {
            if(animationObject.GetBool("Activate"))
            {
                animationObject.SetBool("Activate", false);
            }
            else
            {
                animationObject.SetBool("Activate", true);
            }

            if(lightModifier)
            {
                flashlight.CheckLights(lightOut);
            }

            Destroy(gameObject);
        }
    }
}
