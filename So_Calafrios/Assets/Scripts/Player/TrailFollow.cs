using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailFollow : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;

    // Update is called once per frame
    void Update()
    {
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
