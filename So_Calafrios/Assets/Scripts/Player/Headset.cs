using UnityEngine;
using TMPro;

public class Headset : MonoBehaviour
{
    [SerializeField] private GameObject headset;
    [SerializeField] private Transform invisibleObject;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    void Update()
    {
        if(Input.GetButtonDown("HeadsetToggle"))
        {
            headset.active =
                (headset.active) ? false : true;
            
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
