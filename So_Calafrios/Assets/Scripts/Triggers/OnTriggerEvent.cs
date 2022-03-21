using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Class which manages the inserted events when entering a collider.
/// </summary>
public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] private bool destroyOrNot;
    [SerializeField] private string tagName;
    [SerializeField] private UnityEvent ExecuteFunction;
    [SerializeField] private AudioSource popSound = default;
    
    /// <summary>
    /// Private method called upon colliding with an object.
    /// </summary>
    /// <param name="other">Collider of the collinding object.</param>
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(tagName))
        {
            ExecuteFunction.Invoke();
            popSound.PlayOneShot(popSound.clip);
            if(destroyOrNot)
            {
                Destroy(this);
            }
        }
    }
}
