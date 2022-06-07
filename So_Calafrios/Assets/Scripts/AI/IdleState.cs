using UnityEngine;

/// <summary>
/// Child class of State which defines the Chase State.
/// </summary>
public class IdleState : State
{
    private bool beginActivation = false;
    [SerializeField] private WanderingState wanderingState;

    /// <summary>
    /// Public override method which returns the Chase State.
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

    public void ActivateLord()
    {
        beginActivation = true;
    }
}
