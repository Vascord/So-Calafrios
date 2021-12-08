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

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        // Starts the battery coroutine.
        StartCoroutine(FlashlightBattery());
        lightTime = lightTimeMax;
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // See if player activates/desactivates the light.
        if(Input.GetButtonDown("LightToggle"))
        {
            lightFlashlight.intensity =
                (lightFlashlight.intensity == lightOnIntensity) ? 0 : lightOnIntensity;
        }
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private IEnumerator FlashlightBattery()
    {
        // This is for the battery of the flashlight.
        for(;;)
        {
            // If used, battery goes down.
            if(lightFlashlight.intensity == lightOnIntensity)
            {
                lightTime -= 2;
            }
            // If not used, battery goes up.
            else if(lightTime < lightTimeMax)
            {
                lightTime ++;
            }

            // Minimum battery.
            if(lightTime <= 0)
            {
                lightTime = 0;
                lightFlashlight.intensity = 0;
            }
            // Maximum battery.
            else if(lightTime > 100)
            {
                lightTime = 100;
            }

            // Puts on the interface.
            lightPourcentage.text = $"{lightTime}%";

            yield return new WaitForSeconds(1f);
        }
    }
}
