using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Headset : MonoBehaviour
{
    [SerializeField] private Light flashlight;
    [SerializeField] private Transform invisibleObject;
    [SerializeField] private PostProcessVolume volume;
    private Vignette vignette = null;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        // Fetches the headset
        volume.profile.TryGetSettings(out vignette);
        // Desactivates invisible objects.
        for (int i = 0; i < invisibleObject.childCount; i++)
        {
            invisibleObject.GetChild(i).gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Public method to activates/desactivates the Headset.
    /// </summary>
    public void HeadsetToggle()
    {
        vignette.active = (vignette.active) ? false : true;

        if (flashlight.intensity != 0)
        {
            flashlight.intensity = 0;
        }
        
        // Activates/desactivates invisible objects.
        for(int i = 0; i < invisibleObject.childCount; i++)
        {
            if(invisibleObject.GetChild(i).gameObject.activeSelf)
            {
                invisibleObject.GetChild(i).gameObject.SetActive(false);
                
            }
            else
            {
                invisibleObject.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
