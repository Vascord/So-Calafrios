using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter0Enemy : MonoBehaviour
{
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private float speed;
    private bool chase = false;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void FixedUpdate()
    {
        if(chase)
        {
            transform.LookAt(objectToFollow.position);
            transform.Translate(0f, 0f, speed*Time.deltaTime);
        }
    }

    public void Chase()
    {
        chase = true;
        GetComponent<Animator>().enabled = false;
    }
}
