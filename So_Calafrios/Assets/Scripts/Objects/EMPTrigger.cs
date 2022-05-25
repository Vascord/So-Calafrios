using UnityEngine;

/// <summary>
/// Class which handle the behavior of the EMP trigger on contact.
/// </summary>
public class EMPTrigger : MonoBehaviour
{
    [SerializeField] private float MAX_ZONE_DISTANCE;
    private LayerMask layerMask;
    private RaycastHit hitInfo;

    private void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("Player");
    }

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
            other.gameObject.GetComponent<SimpleSpecters>().AppearLight();
            if(other.gameObject.GetComponent<Animator>())
            {
                other.gameObject.GetComponent<Animator>().enabled = true;
                other.gameObject.GetComponent<Animator>().SetTrigger("Death");
            }
            else
            {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
            PlayerHeadsetDetect();

        }
        // If it hits anything else, it's destroyed.
        else
        {
            Destroy(gameObject);
            PlayerHeadsetDetect();
        }
    }

    private void PlayerHeadsetDetect()
    {
        foreach(Collider collider in Physics.OverlapSphere(
            transform.position, MAX_ZONE_DISTANCE,layerMask))
        {
            collider.transform.GetComponent<Headset>().EMPInterference();
        }
    }
}
