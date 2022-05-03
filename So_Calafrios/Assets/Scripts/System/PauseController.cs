using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PauseController : MonoBehaviour
{
    [SerializeField] private bool pausePhysics;
    [SerializeField] private List<Behaviour> componentsToPause;
    Dictionary<Behaviour, bool> prevBehaviorState;

    private Rigidbody rb3d;
    private Vector3 rb3dPrevVelocity;
    private Vector3 rb3dPrevAngularVelocity;
    private bool rb3dPrevState;

    // Start is called before the first frame update
    void Start()
    {
        PauseManager.Register(OnPause);

        prevBehaviorState = new Dictionary<Behaviour, bool>();
        rb3d = GetComponent<Rigidbody>();

        if(rb3d == null)
        {
            pausePhysics = false;
        }
    }

    private void OnDestroy()
    {
        PauseManager.Unregister(OnPause);
    }

    void OnPause(bool isPaused)
    {
        if(isPaused)
        {
            foreach(var component in componentsToPause)
            {
                if(component.enabled)
                {
                    prevBehaviorState.Add(component, component.enabled);
                    component.enabled = false;
                }
            }

            if(pausePhysics)
            {
                rb3dPrevState = rb3d.isKinematic;
                rb3dPrevVelocity = rb3d.velocity;
                rb3dPrevAngularVelocity = rb3d.angularVelocity;
                rb3d.isKinematic = true;
            }
        }
        else
        {
            foreach (var component in prevBehaviorState.Keys)
            {
                component.enabled = true;
            }

            prevBehaviorState.Clear();

            if(pausePhysics)
            {
                rb3d.isKinematic = rb3dPrevState;
                rb3d.velocity = rb3dPrevVelocity;
                rb3d.angularVelocity = rb3dPrevAngularVelocity;
                rb3d.WakeUp();
            }
        }

    }

    [Button("Add all components")]
    void AddAllComponents()
    {
        componentsToPause = new List<Behaviour>(GetComponents<Behaviour>());
    }
}
