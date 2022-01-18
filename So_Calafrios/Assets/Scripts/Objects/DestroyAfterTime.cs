using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float refreshTime = default;
    [SerializeField] private float maxTime = default;
    private float period, timeDestroy;

    // Update is called once per frame
    void Update()
    {
        // This is for the battery of the flashlight.
        if (period > refreshTime)
        {
            timeDestroy++;
            if(timeDestroy == maxTime)
            {
                Destroy(gameObject);
            }
            period = 0;
        }

        period += Time.deltaTime;
    }
}
