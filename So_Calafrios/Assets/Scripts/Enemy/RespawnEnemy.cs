using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    [SerializeField] private Lord lord;
    [SerializeField] private Transform[] destinationPoints;
    [SerializeField] private float refreshTime = default;
    [SerializeField] private float maxTime = default;
    [SerializeField] private WanderingState wanderingState;
    private float period, timeRespawn;
    private int destinationIndex;

    // Update is called once per frame
    void Update()
    {
        if(lord.dead)
        {
            // This is for the battery of the flashlight.
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

    private void Respawn()
    {
        lord.gameObject.SetActive(true);

        lord.gameObject.GetComponent<StateManager>().currentState = wanderingState;
        lord.dead = false;
        timeRespawn = 0;

        destinationIndex = Random.Range(0, destinationPoints.Length);
        lord.transform.position = destinationPoints[destinationIndex].position;
    }
}
