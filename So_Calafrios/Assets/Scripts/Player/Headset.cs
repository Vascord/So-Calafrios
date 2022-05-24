using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// Class which manages the behavior of the headset.
/// </summary>
public class Headset : MonoBehaviour
{
    [SerializeField] private Light flashlight;
    [SerializeField] private Transform invisibleObjects;
    [SerializeField] private Transform invisibleEnemies;
    [SerializeField] private Volume globalVolume;
    [SerializeField] private Volume headsetVolume;
    [SerializeField] private AudioSource soundHeadset;
    [SerializeField] private Light[] lights;
    private SkinnedMeshRenderer[] invisibleEnemiesSkin;

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

        invisibleEnemiesSkin = invisibleEnemies.GetComponentsInChildren<
            SkinnedMeshRenderer>();

        foreach(SkinnedMeshRenderer invisibleEnemieSkin in invisibleEnemiesSkin)
        {
            invisibleEnemieSkin.enabled = false;
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

        // Activates/desactivates invisible enemies skin.
        foreach(SkinnedMeshRenderer invisibleEnemieSkin in invisibleEnemiesSkin)
        {
            invisibleEnemieSkin.enabled = !invisibleEnemieSkin.enabled;
        }

        // Activates/desactivates lights
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }
    }
}
