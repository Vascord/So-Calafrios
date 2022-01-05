using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // Trail follow enemy. Destroyed if there's no more enemy.
        if(objectToFollow == null)
        {
           Destroy(gameObject);
        }
        else
        {
            transform.position = objectToFollow.position;
        }
    }
}
