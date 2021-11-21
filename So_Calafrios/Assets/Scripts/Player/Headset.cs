using UnityEngine;
using TMPro;

public class Headset : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHeadset;
    [SerializeField] private Transform invisibleObject;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    void Update()
    {
        if(Input.GetButtonDown("HeadsetToggle"))
        {
            textHeadset.enabled =
                (textHeadset.enabled) ? false : true;
            
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
