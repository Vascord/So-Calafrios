using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/// <summary>
/// Class which manages the behavior of the headset.
/// </summary>
public class Headset : MonoBehaviour
{
    [SerializeField] private Light flashlight;
    [SerializeField] private Transform invisibleObject;
    [SerializeField] private PostProcessVolume globalVolume;
    [SerializeField] private PostProcessVolume headsetVolume;


    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
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
        globalVolume.enabled= globalVolume.enabled ? false : true;
        headsetVolume.enabled = headsetVolume.enabled ? false : true;

        if (flashlight.intensity != 0)
        {
            flashlight.intensity = 0;
        }

        // Activates/desactivates invisible objects.
        for (int i = 0; i < invisibleObject.childCount; i++)
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
