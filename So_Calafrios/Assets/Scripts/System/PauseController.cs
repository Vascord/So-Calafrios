using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

/// <summary>
/// Class which manages the pause on the affected objects.
/// </summary>
public class PauseController : MonoBehaviour
{
    [SerializeField] private bool pausePhysics;
    [SerializeField] private List<Behaviour> componentsToPause;
    Dictionary<Behaviour, bool> prevBehaviorState;

    private Rigidbody rb3d;
    private Vector3 rb3dPrevVelocity;
    private Vector3 rb3dPrevAngularVelocity;
    private bool rb3dPrevState;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        PauseManager.Register(OnPause);

        prevBehaviorState = new Dictionary<Behaviour, bool>();
        rb3d = GetComponent<Rigidbody>();

        if(rb3d == null)
        {
            pausePhysics = false;
        }
    }

    /// <summary>
    /// Private method called when the object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        PauseManager.Unregister(OnPause);
    }

    /// <summary>
    /// Public method which does the Pause logic.
    /// </summary>
    /// <param name="isPaused"> Value which determines if its going to pause
    /// or unpause.</param>
    public void OnPause(bool isPaused)
    {
        // If the game is getting paused.
        if(isPaused)
        {
            // Keeps the current state of the stopped component and stops them.
            foreach(var component in componentsToPause)
            {
                if(component.enabled)
                {
                    prevBehaviorState.Add(component, component.enabled);
                    component.enabled = false;
                }
            }

            // Also stops the physics if checked.
            if(pausePhysics)
            {
                rb3dPrevState = rb3d.isKinematic;
                rb3dPrevVelocity = rb3d.velocity;
                rb3dPrevAngularVelocity = rb3d.angularVelocity;
                rb3d.isKinematic = true;
            }
        }
        // If the game is already paused.
        else
        {
            // Starts the components again.
            foreach (var component in prevBehaviorState.Keys)
            {
                component.enabled = true;
            }

            prevBehaviorState.Clear();

            // Starts the physics too if they were stopped.
            if(pausePhysics)
            {
                rb3d.isKinematic = rb3dPrevState;
                rb3d.velocity = rb3dPrevVelocity;
                rb3d.angularVelocity = rb3dPrevAngularVelocity;
                rb3d.WakeUp();
            }
        }

    }

    /// <summary>
    /// Public method which adds every component to the list to stop the 
    /// components.
    /// </summary>
    [Button("Add all components")]
    public void AddAllComponents()
    {
        componentsToPause = new List<Behaviour>(GetComponents<Behaviour>());
    }
}
