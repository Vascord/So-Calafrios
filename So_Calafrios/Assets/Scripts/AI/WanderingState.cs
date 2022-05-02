using UnityEngine;

public class WanderingState : State
{
    [SerializeField] private Lord lord;
    [SerializeField] private ChaseState chaseState;
    [SerializeField] private LayerMask detectionLayer;
    [SerializeField] private bool canSeeThePlayer;

    /// <summary>
    /// Public override method which return the Chase or Wandering state
    /// depending if it can see the player.
    /// </summary>
    public override State RunCurrentState()
    {
        // Get all the colliders of objects within range.
        Collider[] colliders = Physics.OverlapSphere(transform.position, 
            lord.seeRange, detectionLayer);
        for(int i=0; i < colliders.Length;i++)
        {
            CharacterController player = colliders[i].
                transform.GetComponent<CharacterController>();

            // If one of them is has a CharacterController, the following logic
            // will activate.
            if(player != null)
            {
                // Sees if the player is in view range.
                Vector3 targetDirection = player.transform.position - 
                    transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, 
                    transform.forward);

                // If the player is in sight or too close to the Lord, it can
                // see or sense it.
                if((viewableAngle > -lord.viewAngle && viewableAngle <
                    lord.viewAngle) || 
                    Vector3.Distance(player.transform.position,
                    transform.position) < lord.senseRange )
                {
                    canSeeThePlayer = true;
                }
            }
        }

        // Change to Chase state if the Lord can see the player.
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
