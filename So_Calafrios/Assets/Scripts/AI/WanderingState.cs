using UnityEngine;

public class WanderingState : State
{
    [SerializeField] private Lord lord;
    [SerializeField] private ChaseState chaseState;
    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] private bool canSeeThePlayer;

    public override State RunCurrentState()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 
            lord.seeRange, detectionLayer);
        for(int i=0; i < colliders.Length;i++)
        {
            CharacterController player = colliders[i].
                transform.GetComponent<CharacterController>();
            if(player != null)
            {
                Vector3 targetDirection = player.transform.position - 
                    transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, 
                    transform.forward);

                Debug.Log("In range");

                if((viewableAngle > -lord.viewAngle && viewableAngle <
                    lord.viewAngle) || 
                    Vector3.Distance(player.transform.position,
                    transform.position) < lord.senseRange )
                {
                    canSeeThePlayer = true;
                    Debug.Log("Spotted");

                }
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
