/// <summary>
/// Child class of State which defines the Chase State.
/// </summary>
public class ChaseState : State
{
    /// <summary>
    /// Public override method which returns the Chase State.
    /// </summary>
    public override State RunCurrentState()
    {
        return this;
    }
}
