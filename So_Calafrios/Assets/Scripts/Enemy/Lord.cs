using UnityEngine;
using UnityEngine.AI;

public class Lord : MonoBehaviour
{
    public float senseRange;
    public float seeRange;
    [SerializeField] private float wanderSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float destinationPointRange;
    [SerializeField] private int destinationIndex;
    [SerializeField] private Transform[] destinationPoints;
    [SerializeField] private Transform player;
    private NavMeshAgent agent;
    private Vector3 target;
    private StateManager stateManager;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateManager = GetComponent<StateManager>();
        UpdateDestination();
    }

    private void Update() 
    {
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

    private void Wander()
    {
        if(Vector3.Distance(transform.position, target) < destinationPointRange)
        {
            NextDestination();
            UpdateDestination();
        }
    }

    private void Chase() 
    {
        agent.SetDestination(player.transform.position);
    }

    private void UpdateDestination()
    {
        target = destinationPoints[destinationIndex].position;
        agent.SetDestination(target);
    }

    private void NextDestination()
    {
        destinationIndex++;
        if(destinationIndex == destinationPoints.Length)
        {
            destinationIndex = 0;
        }
    }
}
