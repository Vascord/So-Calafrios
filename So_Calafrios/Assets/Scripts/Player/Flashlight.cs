using UnityEngine;

public class Flashlight : MonoBehaviour
{

    [SerializeField] private Light lightFlashlight;
    [SerializeField] private GameObject headset;
    [SerializeField] private float lightOnIntensity;

    /// <summary>
    /// Private method to activate/desactivate the light.
    /// </summary>
    public void ToggleLight()
    {
        if(!headset.active)
        {
            lightFlashlight.intensity = 
                (lightFlashlight.intensity == lightOnIntensity) ? 0 : 
                lightOnIntensity;
        }
    }
}
