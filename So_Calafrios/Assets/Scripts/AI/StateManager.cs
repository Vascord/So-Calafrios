using UnityEngine;

/// <summary>
/// Class which manages the states.
/// </summary>
public class StateManager : MonoBehaviour
{
    public State currentState;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        RunStateMachine();
    }

    /// <summary>
    /// Private method which runs the logic of the state machine.
    /// </summary>
    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if(nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    /// <summary>
    /// Private method which changes the current state based on the next state.
    /// </summary>
    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }

    /// <summary>
    /// Public method which gets the name of the current state.
    /// </summary>
    public string GetCurrentStateName(){
        return currentState.name;
    }
}
