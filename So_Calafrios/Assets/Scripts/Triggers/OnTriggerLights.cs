using UnityEngine;

/// <summary>
/// Class which activates/deactivates the light animations and flashlight when
/// entering a collider.
/// </summary>
public class OnTriggerLights : MonoBehaviour
{
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
            flashlight.CheckLights(lightOut);
            Destroy(this);
        }
    }
}
