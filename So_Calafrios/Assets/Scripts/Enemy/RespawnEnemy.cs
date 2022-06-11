using UnityEngine;

/// <summary>
/// Class which handles the death and respawn of the Lord enemy.
/// </summary>
public class RespawnEnemy : MonoBehaviour
{
    [SerializeField] private Lord lord;
    [SerializeField] private Transform[] destinationPoints;
    [SerializeField] private float refreshTime = default;
    [SerializeField] private float maxTime = default;
    [SerializeField] private WanderingState wanderingState;
    private float period, timeRespawn;
    private int destinationIndex;
    private StateManager lordStateManager;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        lordStateManager = lord.gameObject.GetComponent<StateManager>();
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        //Checks if the Lord is dead
        if(lord.dead)
        {
            // Will start a countdown. At maxTime, the lord respawns.
            if (period > refreshTime)
            {
                timeRespawn++;
                if(timeRespawn == maxTime)
                {
                    Respawn();
                }
                period = 0;
            }

            period += Time.deltaTime;
        }
    }

    /// <summary>
    /// Private method which does the respawn logic of the Lord.
    /// </summary>
    private void Respawn()
    {
        lord.gameObject.SetActive(true);

        lordStateManager.currentState = wanderingState;
        lord.dead = false;
        timeRespawn = 0;

        destinationIndex = Random.Range(0, destinationPoints.Length);
        lord.transform.position = destinationPoints[destinationIndex].position;
    }
}
