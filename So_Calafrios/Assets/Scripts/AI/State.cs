using UnityEngine;

/// <summary>
/// Class which is a base to all States.
/// </summary>
public abstract class State : MonoBehaviour
{
    /// <summary>
    /// Public abstract method which is called by States to apply their logic 
    /// and to define the current State.
    /// </summary>
    public abstract State RunCurrentState();
}
