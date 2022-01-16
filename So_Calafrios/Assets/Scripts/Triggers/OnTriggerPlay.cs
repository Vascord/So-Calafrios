using UnityEngine;

public class OnTriggerPlay : MonoBehaviour
{
    [SerializeField] private AudioSource[] musicObjects;
    [SerializeField] private bool play;

    /// <summary>
    /// Private method called upon colliding with an object.
    /// </summary>
    /// <param name="other">Collider of the collinding object.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Activates animations when player enter.
        if(other.gameObject.CompareTag("Player"))
        {
            foreach(AudioSource music in musicObjects)
            {
                if(play)
                {
                    music.Play();
                }
                else
                {
                    music.Stop();
                }
            }

            Destroy(this);
        }
    }
}
