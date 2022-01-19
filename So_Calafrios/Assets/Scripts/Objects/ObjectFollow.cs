using UnityEngine;

/// <summary>
/// Class which makes an object follow another.
/// </summary>
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
