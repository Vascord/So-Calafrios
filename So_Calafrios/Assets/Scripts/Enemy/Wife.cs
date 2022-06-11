using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Class which contains the behavoir of the Wife enemy.
/// </summary>
public class Wife : MonoBehaviour
{
    [SerializeField] private float chaseSpeed;
    [SerializeField] private GameObject deadLigth;
    [SerializeField] private LayerMask detectionLayer;
    private NavMeshAgent agent;


    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = chaseSpeed;
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update() 
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1000, 
            detectionLayer);
        for(int i=0; i < colliders.Length;i++)
        {
            CharacterController player = colliders[i].
                transform.GetComponent<CharacterController>();

            // If one of them is has a CharacterController, the following logic
            // will activate.
            if(player != null)
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }

    /// <summary>
    /// Public method that instantiates the dead light object.
    /// </summary>
    public void AppearLight()
    {
        Instantiate(deadLigth, transform.position, transform.rotation);
    }
}
