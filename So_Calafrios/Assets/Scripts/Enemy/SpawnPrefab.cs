using UnityEngine;

/// <summary>
/// Class which spawns prefabs at the game object position and as a child if
/// needed.
/// </summary>
public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private bool asChild;

    /// <summary>
    /// Public method which does the spawn logic.
    /// </summary>
    public void SpawnObject()
    {
        GameObject instantPrefab = Instantiate(prefab, transform.position, 
            transform.rotation);
        if(asChild)
        {
            instantPrefab.transform.parent = gameObject.transform;
        }
    }
}
