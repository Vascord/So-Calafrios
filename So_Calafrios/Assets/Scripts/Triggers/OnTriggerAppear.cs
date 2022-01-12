using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerAppear : MonoBehaviour
{
    [SerializeField] private GameObject appearObject;

    /// <summary>
    /// Private method called upon colliding with an object.
    /// </summary>
    /// <param name="other">Collider of the collinding object.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Activates animations when player enter.
        if(other.gameObject.CompareTag("Player"))
        {
            appearObject.SetActive(true);
            Destroy(this);
        }
    }
}
