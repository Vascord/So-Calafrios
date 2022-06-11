using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

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
    [SerializeField] private AudioSource staticNoiseHeadset;
    [SerializeField] private Light[] lights;
    [SerializeField] private float refreshTime = default;
    [SerializeField] private float maxTime = default;
    private float period, timeFreeze;
    private Camera cam;
    private int tempCul;
    private CameraClearFlags tempFlag;
    private SkinnedMeshRenderer[] invisibleEnemiesSkin;
    private bool cameraFreeze;
    private bool firstFreeze;
    private FilmGrain headsetGrain;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        // Desactivates invisible objects and enemy skin.
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

        cameraFreeze = false;
        firstFreeze = true;

        headsetVolume.profile.TryGet<FilmGrain>(out headsetGrain);
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        if(cameraFreeze)
        {
            if(headsetVolume.enabled && firstFreeze)
            {
                FreezeCamera();
            }

            // After the period of time, the camera unfreezes.
            if (period > refreshTime)
            {
                timeFreeze++;
                if(timeFreeze == maxTime)
                {
                    cameraFreeze = false;
                    if(headsetVolume.enabled)
                    {
                        UnfreezeCamera();
                    }
                    timeFreeze = 0;
                }
                period = 0;
            }

            period += Time.deltaTime;
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

        else if(!headsetVolume.enabled && cameraFreeze)
        {
            UnfreezeCamera();
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
            if(invisibleEnemieSkin != null)
            {
                invisibleEnemieSkin.enabled = !invisibleEnemieSkin.enabled;
            }
        }

        // Activates/desactivates lights
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }
    }
    
    /// <summary>
    /// Public method which starts the headset static and freeze.
    /// </summary>
    public void EMPInterference()
    {
        cameraFreeze = true;
        timeFreeze = 0;
    }

    /// <summary>
    /// Private method that Freezes the headset and creates the static.
    /// </summary>
    private void FreezeCamera()
    {
        firstFreeze = false;
        cam = Camera.main;
        tempCul = cam.cullingMask;
        tempFlag = cam.clearFlags;
        cam.clearFlags = CameraClearFlags.Nothing;
        cam.cullingMask = 0;
        headsetGrain.intensity.value = 1f;
        staticNoiseHeadset.Play();
    }

    /// <summary>
    /// Public method that stop the freeze and static.
    /// </summary>
    private void UnfreezeCamera()
    {
        firstFreeze = true;
        cam = Camera.main;
        cam.cullingMask = tempCul;
        cam.clearFlags = tempFlag;
        headsetGrain.intensity.value = 0.4f;
        staticNoiseHeadset.Stop();
    }

    /// <summary>
    /// Public method to update the enemy skin visibility depending of the
    /// headset volume activation.
    /// </summary>
    public void UpdateEnemiesSkin()
    {
        invisibleEnemiesSkin = invisibleEnemies.GetComponentsInChildren<
            SkinnedMeshRenderer>();

        foreach(SkinnedMeshRenderer invisibleEnemieSkin in invisibleEnemiesSkin)
        {
            invisibleEnemieSkin.enabled = headsetVolume.enabled;
        }
    }
}
