using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnHitKill : MonoBehaviour
{
    /// <summary>
    /// Private method called upon colliding with an object.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // If it hits the player, it "dies" and return to menu.
        if(other.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Menu");
        }
    }
}