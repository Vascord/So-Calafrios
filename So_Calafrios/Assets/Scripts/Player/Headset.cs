using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/// <summary>
/// Class which manages the behavior of the headset.
/// </summary>
public class Headset : MonoBehaviour
{
    [SerializeField] private Light flashlight;
    [SerializeField] private Transform invisibleObjects;
    [SerializeField] private PostProcessVolume globalVolume;
    [SerializeField] private PostProcessVolume headsetVolume;
    [SerializeField] private AudioSource soundHeadset;
    [SerializeField] private Light[] lights;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        // Desactivates invisible objects.
        for (int i = 0; i < invisibleObjects.childCount; i++)
        {
            invisibleObjects.GetChild(i).gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Public method to activates/desactivates the Headset.
    /// </summary>
    public void HeadsetToggle()
    {
        globalVolume.enabled= !globalVolume.enabled;
        headsetVolume.enabled = !headsetVolume.enabled;

        if (flashlight.intensity != 0)
        {
            flashlight.intensity = 0;
        }

        soundHeadset.PlayOneShot(soundHeadset.clip);

        // Activates/desactivates invisible objects.
        for (int i = 0; i < invisibleObjects.childCount; i++)
        {
            if(invisibleObjects.GetChild(i).gameObject.activeSelf)
            {
                invisibleObjects.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                invisibleObjects.GetChild(i).gameObject.SetActive(true);
            }
        }

        // Activates/desactivates lights
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }
    }
}
