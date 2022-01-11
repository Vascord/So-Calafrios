using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Flashlight : MonoBehaviour
{

    [SerializeField] private Light lightFlashlight;
    [SerializeField] private PostProcessVolume volume;
    [SerializeField] private float lightOnIntensity;
    private Vignette vignette = null;

    private void Start()
    {
        volume.profile.TryGetSettings(out vignette);
    }

    /// <summary>
    /// Private method to activate/desactivate the light.
    /// </summary>
    public void ToggleLight()
    {
        if(!vignette.active)
        {
            lightFlashlight.intensity = 
                (lightFlashlight.intensity == lightOnIntensity) ? 0 : 
                lightOnIntensity;
        }
    }
}
