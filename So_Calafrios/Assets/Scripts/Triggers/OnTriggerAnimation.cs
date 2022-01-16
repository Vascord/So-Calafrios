using UnityEngine;

public class OnTriggerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animationObject;

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
            Destroy(gameObject);
        }
    }
}
