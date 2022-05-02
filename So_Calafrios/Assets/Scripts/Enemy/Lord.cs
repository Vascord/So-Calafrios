using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Class which contains the behavoir of the Lord enemy depending of his State.
/// </summary>
public class Lord : MonoBehaviour
{
    public float senseRange;
    public float seeRange;
    public float viewAngle;
    [SerializeField] private float wanderSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float destinationPointRange;
    [SerializeField] private int destinationIndex;
    [SerializeField] private Transform[] destinationPoints;
    [SerializeField] private Transform player;
    private NavMeshAgent agent;
    private Vector3 target;
    private StateManager stateManager;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateManager = GetComponent<StateManager>();
        UpdateDestination();
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update() 
    {
        // Depending of the it's state, it will do a certain behavior.
        switch (stateManager.GetCurrentStateName()) 
        {
            case "Wandering State":
            {
                agent.speed = wanderSpeed;
                Wander();
                break;
            }

            case "Chase State":
            {
                agent.speed = chaseSpeed;
                Chase();
                break;
            }
        }
    }

    /// <summary>
    /// Private method called to do the Wandering behavior of the Lord.
    /// </summary>
    private void Wander()
    {
        if(Vector3.Distance(transform.position, target) < destinationPointRange)
        {
            NextDestination();
            UpdateDestination();
        }
    }

    /// <summary>
    /// Private method called to do the Chase behavior of the Lord.
    /// </summary>
    private void Chase() 
    {
        agent.SetDestination(player.transform.position);
    }

    /// <summary>
    /// Private method called to update the next destination.
    /// </summary>
    private void UpdateDestination()
    {
        target = destinationPoints[destinationIndex].position;
        agent.SetDestination(target);
    }

    /// <summary>
    /// Private method called to get the next destination to Update.
    /// </summary>
    private void NextDestination()
    {
        destinationIndex++;
        if(destinationIndex == destinationPoints.Length)
        {
            destinationIndex = 0;
        }
    }
}
