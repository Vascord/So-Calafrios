using UnityEngine;

/// <summary>
/// Class which handle the behavior of the EMP trigger on contact.
/// </summary>
public class EMPTrigger : MonoBehaviour
{
    private Camera cam;
    private int tempCul;
    private CameraClearFlags tempFlag;
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
        }
        // If it hits anything else, it's destroyed.
        else
        {
            Destroy(gameObject);
        }
    }
    private void FreezeCamera()
    {
        cam = Camera.main;
        tempCul = cam.cullingMask;
        tempFlag = cam.clearFlags;
        cam.clearFlags = CameraClearFlags.Nothing;
        cam.cullingMask = 0;
    }
    void UnfreezeCamera()
    {
        Debug.Log(tempCul);
        Debug.Log(tempFlag);
        cam = Camera.main;
        cam.cullingMask = tempCul;
        cam.clearFlags = tempFlag;
    }
}
