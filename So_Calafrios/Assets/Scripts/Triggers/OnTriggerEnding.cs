using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnding : MonoBehaviour
{
    [SerializeField] private Animator animationObject;

    /// <summary>
    /// Private method called upon colliding with an object.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // Activates animations when player enter.
        if(other.gameObject.CompareTag("Player"))
        {
            animationObject.SetTrigger("Ending");
            Destroy(gameObject);
        }
    }
}
