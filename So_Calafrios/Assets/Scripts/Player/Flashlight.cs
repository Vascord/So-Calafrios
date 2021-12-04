using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour
{

    [SerializeField] private Light lightFlashlight;
    [SerializeField] private float lightOnIntensity;
    [SerializeField] private float lightTimeMax;
    private float lightTime;

    void Start()
    {
        StartCoroutine(FlashlightBattery());
        lightTime = lightTimeMax;
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    void Update()
    {
        if(Input.GetButtonDown("LightToggle"))
        {
            lightFlashlight.intensity =
                (lightFlashlight.intensity == lightOnIntensity) ? 0 : lightOnIntensity;
        }

        if(lightTime <= 0)
        {
            lightTime = 0;
            lightFlashlight.intensity = 0;
        }
        else if(lightTime > 100)
        {
            lightTime = 100;
        }
    }

    IEnumerator FlashlightBattery()
    {
        for(;;)
        {
            if(lightFlashlight.intensity == lightOnIntensity)
            {
                lightTime -= 2;
            }
            else if(lightTime < lightTimeMax)
            {
                lightTime ++;
            }

            yield return new WaitForSeconds(1f);

            Debug.Log(lightTime);
        }
    }
}
