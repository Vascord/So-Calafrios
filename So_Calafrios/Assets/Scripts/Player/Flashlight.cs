using UnityEngine;

public class Flashlight : MonoBehaviour
{

    [SerializeField] private Light lightFlashlight;
    [SerializeField] private GameObject headset;
    [SerializeField] private float lightOnIntensity;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // See if player activates/desactivates the light.
        if(Input.GetButtonDown("LightToggle") && !(headset.active))
        {
            lightFlashlight.intensity =
                (lightFlashlight.intensity == lightOnIntensity) ? 0 : lightOnIntensity;
        }
    }
}
