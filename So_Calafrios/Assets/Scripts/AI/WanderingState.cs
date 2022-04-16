using UnityEngine;

public class WanderingState : State
{
    [SerializeField] private Lord lord;
    [SerializeField] private ChaseState chaseState;
    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] private bool canSeeThePlayer;

    public override State RunCurrentState()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, lord.senseRange, detectionLayer);
        for(int i=0; i < colliders.Length;i++)
        {
            CharacterController player = colliders[i].transform.GetComponent<CharacterController>();
            if(player != null)
            {
                canSeeThePlayer = true;
            }
        }

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
