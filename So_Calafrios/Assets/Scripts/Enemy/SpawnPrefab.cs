using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private bool asChild;

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
