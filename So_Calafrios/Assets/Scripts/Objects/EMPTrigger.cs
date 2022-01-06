using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPTrigger : MonoBehaviour
{
    /// <summary>
    /// Private method called upon colliding with an object.
    /// </summary>
    /// <param name="other">Collider of the collinding object.</param>
    private void OnTriggerEnter(Collider other)
    {
        // If it hits the player or certain objects, it does nothing.
        if(other.gameObject.CompareTag("Player") ||
        other.gameObject.CompareTag("IgnoreEMP")){}
        // If it hits the enemy, destroy the enemy and object.
        else if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        // If it hits anything else, it's destroyed.
        else
        {
            Destroy(gameObject);
        }
    }
}
