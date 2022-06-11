using UnityEngine;

/// <summary>
/// Class which handle the behavior of the EMP trigger on contact.
/// </summary>
public class EMPTrigger : MonoBehaviour
{
    [SerializeField] private float MAX_ZONE_DISTANCE;
    [SerializeField] private GameObject electricEffect;
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
        else if(other.gameObject.GetComponent<SimpleSpecters>())
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

            DestroyEMP();
        }
        else if(other.gameObject.GetComponent<Wife>())
        {
            other.gameObject.GetComponent<Wife>().AppearLight();

            if(other.gameObject.GetComponent<Animator>())
            {
                other.gameObject.GetComponent<Animator>().enabled = true;
                other.gameObject.GetComponent<Animator>().SetTrigger("Death");
            }
            else
            {
                Destroy(other.gameObject);
            }

            DestroyEMP();
        }
        else if(other.gameObject.GetComponent<Lord>())
        {
            other.gameObject.GetComponent<Lord>().AppearLight();

            DestroyEMP();
        }
        // If it hits anything else, it's destroyed.
        else
        {
            DestroyEMP();
        }
    }

    /// <summary>
    /// Private method which destroys the EMP and instantiate the effects and
    /// creates the effect of the headset interference.
    /// </summary>
    private void DestroyEMP()
    {
        foreach(Collider collider in Physics.OverlapSphere(
            transform.position, MAX_ZONE_DISTANCE,layerMask))
        {
            collider.transform.GetComponent<Headset>().EMPInterference();
        }

        Instantiate(electricEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
