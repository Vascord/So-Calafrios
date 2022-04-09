using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingState : State
{
    [SerializeField] private ChaseState chaseState;
    [SerializeField] private LayerMask detectionLayer;
        [SerializeField] private float detectionRadius;
    [SerializeField] private bool canSeeThePlayer;

    public override State RunCurrentState()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);
        for(int i=0; i < colliders.Length;i++)
        {
            CharacterController player = colliders[i].transform.GetComponent<CharacterController>();
            if(player != null)
            {
                canSeeThePlayer = true;
            }
        }

        Debug.Log("I'm wandering");

        if(canSeeThePlayer)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }
}
