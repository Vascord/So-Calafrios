using UnityEngine;

public class Flashlight : MonoBehaviour
{

    [SerializeField] private Light lightFlashlight;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    void Update()
    {
        if(Input.GetButtonDown("LightToggle"))
        {
            lightFlashlight.intensity =
                (lightFlashlight.intensity == 1.5f) ? 0 : 1.5f;
        }
    }
}
