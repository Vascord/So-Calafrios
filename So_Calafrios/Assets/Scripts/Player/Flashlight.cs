using UnityEngine;
using System.Collections;
using TMPro;

public class Flashlight : MonoBehaviour
{

    [SerializeField] private Light lightFlashlight;
    [SerializeField] private float lightOnIntensity;
    [SerializeField] private float lightTimeMax;
    [SerializeField] private TextMeshProUGUI lightPourcentage;
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

            if(lightTime <= 0)
            {
                lightTime = 0;
                lightFlashlight.intensity = 0;
            }
            else if(lightTime > 100)
            {
                lightTime = 100;
            }

            lightPourcentage.text = $"{lightTime}%";

            yield return new WaitForSeconds(1f);
        }
    }
}
