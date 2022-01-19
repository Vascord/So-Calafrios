using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/// <summary>
/// Class which manages the behavior of the flashlight.
/// </summary>
public class Flashlight : MonoBehaviour
{
    [SerializeField] private Light lightFlashlight;
    [SerializeField] private PostProcessVolume volume;
    [SerializeField] private float lightOnIntensity;
    private Vignette vignette = null;
    private bool lightsOut;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        volume.profile.TryGetSettings(out vignette);
    }

    /// <summary>
    /// Public method to activate/desactivate the light.
    /// </summary>
    public void ToggleLight()
    {
        if(!vignette.active && !lightsOut)
        {
            lightFlashlight.intensity = 
                (lightFlashlight.intensity == lightOnIntensity) ? 0 : 
                lightOnIntensity;
        }
    }

    /// <summary>
    /// Private method to activate/desactivate the flashlight when the lights.
    /// </summary>
    /// <param name="check"> Says if the flashlight is activable or 
    /// not.</param>
    public void CheckLights(bool check)
    {
        lightsOut = check;
        lightFlashlight.intensity = 0;
    }
}
