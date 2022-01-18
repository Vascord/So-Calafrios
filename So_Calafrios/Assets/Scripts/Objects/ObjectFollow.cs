using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    { 
        if(objectToFollow != null)
        {
            transform.position = objectToFollow.position;
        }
    }
}
