using UnityEngine;

public class Headset : MonoBehaviour
{
    [SerializeField] private GameObject headset;
    [SerializeField] private Light flashlight;
    [SerializeField] private Transform invisibleObject;

    /// <summary>
    /// Private method called before the first frame.
    /// </summary>
    private void Start()
    {
        // Desactivates invisible objects.
        for(int i = 0; i < invisibleObject.childCount; i++)
        {
            invisibleObject.GetChild(i).gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Update()
    {
        // Sees if the player activates/desactivates the Headset.
        if(Input.GetButtonDown("HeadsetToggle"))
        {
            headset.active = (headset.active) ? false : true;

            if(flashlight.intensity != 0)
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
}
