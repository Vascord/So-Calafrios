using UnityEngine;

public class OnHitKillPlayer : MonoBehaviour
{

    /// <summary>
    /// Private method called upon colliding with an object.
    /// </summary>
    /// <param name="other">Collider of the collinding object.</param>
    private void OnTriggerEnter(Collider other)
    {
        // If it hits the player, it "dies" and return to menu.
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerDeath>().Death();
        }
    }
}
