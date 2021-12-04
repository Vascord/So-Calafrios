using UnityEngine;

public class Flashlight : MonoBehaviour
{

    [SerializeField] private Light lightFlashlight;
    [SerializeField] private float lightOnIntensity;

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
}
