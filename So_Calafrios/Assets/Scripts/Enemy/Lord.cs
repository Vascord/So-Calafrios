using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Class which contains the behavior of the Lord enemy depending of his State.
/// </summary>
public class Lord : MonoBehaviour
{
    public float senseRange;
    public float seeRange;
    public float viewAngle;
    public bool dead;
    [SerializeField] private float extraRange;
    [SerializeField] private float musicRange;
    [SerializeField] private float wanderSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float speedGain;
    [SerializeField] private float destinationPointRange;
    [SerializeField] private Transform[] destinationPoints;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject deadLigth;
    [SerializeField] private AudioSource spookyMusic;
    [SerializeField] private AudioSource normalMusic;
    [SerializeField] private AudioSource wind;
    [SerializeField] private LayerMask detectionLayer;
    private NavMeshAgent agent;
    private Vector3 target;
    private StateManager stateManager;
    private int destinationIndex = -1;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateManager = GetComponent<StateManager>();
        destinationIndex = Random.Range(0, destinationPoints.Length);
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

        // Get all the colliders of objects within range.
        Collider[] colliders = Physics.OverlapSphere(transform.position, 
            musicRange, detectionLayer);
        for(int i=0; i < colliders.Length;i++)
        {
            CharacterController player = colliders[i].
                transform.GetComponent<CharacterController>();

            // If one of them is has a CharacterController, the following logic
            // will activate.
            if(player != null)
            {
                if(!spookyMusic.isPlaying)
                {
                    spookyMusic.Play();
                    normalMusic.volume = 0.05f;
                    wind.volume = 0.025f;
                }
            }
        }

        // If no CharacterController in the collider, then this logic activates
        if(colliders.Length == 0)
        {
            if(spookyMusic.isPlaying)
            {
                spookyMusic.Stop();
                normalMusic.volume = 0.1f;
                wind.volume = 0.05f;
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

        agent.SetDestination(target);
        
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
    }

    /// <summary>
    /// Private method called to get the next destination to Update.
    /// </summary>
    private void NextDestination()
    {
        destinationIndex = Random.Range(0, destinationPoints.Length);
    }

    /// <summary>
    /// Public method that instantiates the dead light object and changes 
    /// some values on the death of the lord.
    /// </summary>
    public void AppearLight()
    {
        Instantiate(deadLigth, transform.position, transform.rotation);
        spookyMusic.Stop();
        normalMusic.volume = 0.1f;
        dead = true;
        wanderSpeed += speedGain;
        chaseSpeed += speedGain * 1.5f;
        seeRange += extraRange;
        senseRange += extraRange;
        gameObject.SetActive(false);
    }
}
