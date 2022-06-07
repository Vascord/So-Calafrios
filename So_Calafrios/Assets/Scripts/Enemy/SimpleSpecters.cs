using UnityEngine;

/// <summary>
/// Class which does the behaviors and actions of the specter enemies.
/// </summary>
public class SimpleSpecters : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private float speed;
    [SerializeField] private GameObject deadLigth;
    [SerializeField] private float countdown;
    private bool chase;
    private AudioSource whispers;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        whispers = GetComponentInChildren<AudioSource>();
    }

    /// <summary>
    /// Private method called 60 times per second.
    /// </summary>
    private void FixedUpdate()
    {
        if(chase)
        {
            if(countdown <= 0)     
            {        
                // This will make the entity look at the other object follow it.
                transform.LookAt(objectToFollow.position);
                transform.Translate(0f, 0f, speed*Time.deltaTime);     
            } 
            else
            {
                countdown -= Time.deltaTime;   
            }
        }
    }

    /// <summary>
    /// Public method called to activate the chase of the enemy.
    /// </summary>
    public void Chase()
    {
        chase = true;
        whispers.Play();
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
