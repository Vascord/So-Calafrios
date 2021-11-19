using UnityEngine;
using TMPro;

public class Headset : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHeadset;

    /// <summary>
    /// Private method called every frame.
    /// </summary>
    void Update()
    {
        if(Input.GetButtonDown("HeadsetToggle"))
        {
            textHeadset.enabled =
                (textHeadset.enabled) ? false : true;
        }
    }
}
