using UnityEngine;

/// <summary>
/// Class which does the behaviors and actions of the specter enemies.
/// </summary>
public class Chapter0Enemy : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private float speed;
    [SerializeField] private GameObject deadLigth;
    private bool chase;

    /// <summary>
    /// Private method called 60 times per second.
    /// </summary>
    private void FixedUpdate()
    {
        if(chase)
        {
            // This will make the entity look at the other object follow it.
            transform.LookAt(objectToFollow.position);
            transform.Translate(0f, 0f, speed*Time.deltaTime);
        }
    }

    /// <summary>
    /// Public method called to activate the chase of the enemy.
    /// </summary>
    public void Chase()
    {
        chase = true;
        if(GetComponent<Animator>()){GetComponent<Animator>().enabled = false;}
    }

    /// <summary>
    /// Public method called to destroy the game object.
    /// </summary>
    public void Destroy()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Public method that instantiates the dead light object.
    /// </summary>
    public void AppearLight()
    {
        Instantiate(deadLigth, transform.position, transform.rotation);
    }
}
