using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    /// <summary>
    /// Private method called upon colliding with an object.
    /// </summary>
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
