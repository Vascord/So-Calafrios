using UnityEngine;

/// <summary>
/// Child class of State which defines the Idle State.
/// </summary>
public class IdleState : State
{
    private bool beginActivation = false;
    [SerializeField] private WanderingState wanderingState;

    /// <summary>
    /// Public override method which returns the Idle or Wandering State,
    /// depending if the player entered the garden.
    /// </summary>
    public override State RunCurrentState()
    {
        if(beginActivation)
        {
            return wanderingState;
        }
        else
        {
            return this;
        }
    }

    /// <summary>
    /// Public method which activates the Wandering State when the player enters
    /// the garden.
    /// </summary>
    public void ActivateLord()
    {
        beginActivation = true;
    }
}
