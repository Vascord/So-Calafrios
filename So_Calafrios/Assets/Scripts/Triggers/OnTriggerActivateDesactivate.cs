using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerActivateDesactivate : MonoBehaviour
{
    [SerializeField] private GameObject activableObject;
    [SerializeField] private bool activationDesactivation;

    /// <summary>
    /// Private method called upon colliding with an object.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // Activates animations when player enter.
        if(other.gameObject.CompareTag("Player"))
        {
            activableObject.SetActive(activationDesactivation);
            Destroy(gameObject);
        }
    }
}
