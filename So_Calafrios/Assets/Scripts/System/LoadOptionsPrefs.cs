using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

/// <summary>
/// Class which manages the load of the player's options.
/// </summary>
public class LoadOptionsPrefs : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer = default;
    [SerializeField] private MouseLook mouse = default;
    [SerializeField] private Light sceneLight = default;
    [SerializeField] private Camera cameraObject = default;
    [SerializeField] private Button lvl2Button = default;
    [SerializeField] private RawImage lvl2Image = default;


    /// <summary>
    /// Private method called every frame.
    /// </summary>
    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if(PlayerPrefs.GetInt("quality") != 0)
            {
                QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
            }

            if(PlayerPrefs.GetFloat("volume") != 0)
            {
                audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
            }

            if(PlayerPrefs.GetString("screen") != null)
            {
                Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.
                    GetString("screen"));
            }

            if(PlayerPrefs.GetString("lvl2") == "true")
            {
                lvl2Button.interactable = Convert.ToBoolean(PlayerPrefs.
                    GetString("lvl2"));
                lvl2Image.enabled = Convert.ToBoolean(PlayerPrefs.
                    GetString("lvl2"));
            }
        }
        else
        {
            if(PlayerPrefs.GetFloat("mouse sensitivity") != 0)
            {
                mouse.mouseSensitivity = PlayerPrefs.
                    GetFloat("mouse sensitivity");
            }
            if(PlayerPrefs.GetFloat("brightness") != 0)
            {
                sceneLight.intensity = PlayerPrefs.GetFloat("brightness");
            }
            if(PlayerPrefs.GetFloat("FOV") != 0)
            {
                cameraObject.fieldOfView = PlayerPrefs.GetFloat("FOV");
            }
        }
    }
}
