using UnityEngine;

public class Chapter0Enemy : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private float speed;
    [SerializeField] private GameObject deadLigth;
    private bool chase;

    /// <summary>
    /// Private method called every frame.
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

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void AppearLight()
    {
        Instantiate(deadLigth, transform.position, transform.rotation);
    }
}
