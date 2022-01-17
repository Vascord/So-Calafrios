using UnityEngine;

public class OnTriggerActivateEnemies : MonoBehaviour
{
    [SerializeField] private Chapter0Enemy[] enemies;

    /// <summary>
    /// Private method called upon colliding with an object.
    /// </summary>
    /// <param name="other">Collider of the collinding object.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Activates animations when player enter.
        if(other.gameObject.CompareTag("Player"))
        {
            foreach(Chapter0Enemy enemy in enemies)
            {
                enemy.enabled = true;
                enemy.Chase();
                enemy.gameObject.GetComponentInChildren<AudioSource>().enabled =
                    true;
            }

            Destroy(gameObject);
        }
    }
}
